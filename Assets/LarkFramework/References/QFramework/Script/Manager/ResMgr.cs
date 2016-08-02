﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using QFramework;

// 资源管理器，封装开发模式和发布模式
namespace QFramework {
	public class ResMgr : QMonoSingleton<ResMgr>,IMgr
	{
		public GameObject LoadUIPrefabSync(string uiName)
		{
			return Resources.Load<GameObject>("UIPrefab/" + uiName);
		}

		// 正在加载的资源映射
		private Dictionary<string, IResLoader> loadingResDict = null;
		// 正在加载的资源映射中加载完成的资源列表，准备删除，避免遍历删除的语法规则
		private List<string> loadedResList = null;
		// 正在加载的场景
		private SceneLoader sceneLoader = null;
		private SceneLoader deleteSceneLoader = null;

		// 已经加载完成的AssetBundle
		private Dictionary<string, AssetBundleLoader> loadedAssetBundleLoaderDict = null;
		private Dictionary<string, AssetBundleSceneLoader> loadedAssetBundleSceneLoaderDict = null;
		// AssetBundleManifest
		private AssetBundleManifest manifest = null;

		/// <summary>
		/// /AssetBundles这个要理解一下
		/// </summary>
		private ResMgr()
		{

			this.loadedAssetBundleLoaderDict = new Dictionary<string, AssetBundleLoader>();
			this.loadedAssetBundleSceneLoaderDict = new Dictionary<string, AssetBundleSceneLoader>();
			this.loadingResDict = new Dictionary<string, IResLoader>();
			this.loadedResList = new List<string>(20);
			QApp.Instance().onUpdate += Update;
			QApp.Instance().onDestroy += OnDestroy;
		}

		/// <summary>
		/// 保证在ASSETBUNDLE方式下，首先加载资源清单
		/// </summary>
		/// <returns></returns>
		public IEnumerator Init()
		{
			yield return null;
			#if ASSETBUNDLE
			WWW www = new WWW(AssetBundlePath + "AssetBundles");
			yield return www;
			this.manifest = www.assetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
			#else
			yield return null;
			#endif
		}

		void Update()
		{
			// 检查场景是否加载完成
			if (this.sceneLoader != null)
			{
				if (this.sceneLoader.IsDone())
				{
					SceneLoader loader = this.sceneLoader;
					#if ASSETBUNDLE
					this.loadedAssetBundleSceneLoaderDict[loader.SceneName] = this.sceneLoader as AssetBundleSceneLoader;
					#endif
					this.sceneLoader = null;
					if (loader.LoadDoneCallback != null)
						loader.LoadDoneCallback(loader.SceneName);
				}
				else
				{
					if (this.sceneLoader.LoadUpdateCallback != null)
						this.sceneLoader.LoadUpdateCallback(this.sceneLoader.SceneName, this.sceneLoader.GetProgress());
				}
			}
			// 遍历正在加载的资源，检测是否已经加载完成
			foreach (KeyValuePair<string, IResLoader> resLoaderKV in this.loadingResDict)
			{
				string resName = resLoaderKV.Key;
				IResLoader loader = resLoaderKV.Value;
				if (loader.IsDone())
				{
					//Debug.Log(string.Format("{0} done at {1}", resName, Time.frameCount));
					this.loadedResList.Add(resName);
				}
			}
			// 规避遍历字典删除元素的语法，在加载完成后可能会再次启动加载
			for (int i = 0; i < this.loadedResList.Count; ++i)
			{
				string resName = this.loadedResList[i];
				IResLoader loader = this.loadingResDict[resName];
				#if ASSETBUNDLE
				// 加入到缓存的AssetBundle列表
				AssetBundleLoader abLoader = loader as AssetBundleLoader;
				this.loadedAssetBundleLoaderDict[resName] = abLoader;
				#endif
				if (loader.LoadDoneCallback != null)
					loader.LoadDoneCallback(resName, loader.GetResObj());
				this.loadingResDict.Remove(resName);
			}
			this.loadedResList.Clear();
		}

		void OnDestroy()
		{
			// 卸载所有资源，避免编辑器异常
			if (null != this.loadingResDict) {
				this.loadingResDict.Clear ();
				this.loadingResDict = null;
			}

			if (null != this.loadedResList) {
				this.loadedResList.Clear ();
				this.loadedResList = null;
			}
				
			if (null != this.loadedAssetBundleLoaderDict) {
				this.loadedAssetBundleLoaderDict.Clear ();
				this.loadedAssetBundleLoaderDict = null;
			}

			Resources.UnloadUnusedAssets();
		}

		/// <summary>
		/// 获取资源依赖
		/// </summary>
		/// <param name="res">资源名</param>
		/// <returns>依赖资源名</returns>
		public string[] GetDependences(string res)
		{
			QLog.Assert(!string.IsNullOrEmpty(res), "GetDependeces res is NULL");
			return this.manifest.GetAllDependencies(res.ToLower());
		}

		/// <summary>
		/// 判断是否是已经加载完成的资源
		/// </summary>
		/// <param name="res">资源名</param>
		/// <returns></returns>
		public bool IsLoadedAssetBundle(string res)
		{
			return this.loadedAssetBundleLoaderDict.ContainsKey(res);
		}

		/// <summary>
		/// 加载资源
		/// </summary>
		/// <param name="resName"></param>
		/// <param name="loadDone"></param>
		/// <param name="updateProgress"></param>
		public void LoadRes(string resName, ResourceLoader.LoadResDoneCallback loadDone = null)
		{
			IResLoader loader = null;
			#if ASSETBUNDLE
			AssetBundleLoader abLoader = null;
			// 如果已经加载过这个AssetBundle
			if (this.loadedAssetBundleLoaderDict.TryGetValue(resName, out abLoader))
			{
			// 检查依赖及assetbundle解压
			abLoader.CheckDependences();
			this.loadedAssetBundleLoaderDict.Remove(resName);
			this.loadingResDict[resName] = abLoader;
			return;
			}
			#endif
			// 如果正在加载中，则将加载回调添加到已有的加载器
			if (this.loadingResDict.TryGetValue(resName, out loader))
			{
				//Debug.LogWarning(resName + " loading");
				if (loadDone != null)
					loader.LoadDoneCallback += loadDone;
				return;
			}
			// 新建加载器开始加载
			#if ASSETBUNDLE
			loader = new AssetBundleLoader(resName, loadDone);
			#else
			loader = new ResourceLoader(resName, loadDone);
			#endif
			// 添加至正在加载列表
			AddLoadingLoader(loader);
			// 启动加载
			QApp.Instance().StartCoroutine(loader);
		}

		/// <summary>
		/// 加载场景
		/// </summary>
		/// <param name="sceneName">场景名</param>
		/// <param name="additive">是叠加加载，还是独立加载</param>
		/// <param name="loadDone">加载完成回调</param>
		/// <param name="updateProgress">加载进度更新回调</param>
		public void LoadScene(string sceneName, bool additive, 
			SceneLoader.LoadSceneDoneCallback loadDone, SceneLoader.LoadSceneUpdateCallback updateProgress)
		{
			SceneLoader loader = null;
			#if ASSETBUNDLE
			// TODO 检查已经加载的情况

			loader = new AssetBundleSceneLoader(sceneName, additive, loadDone, updateProgress);
			#else
			loader = new SceneLoader(sceneName, additive, loadDone, updateProgress);
			#endif
			// 启动加载
			QApp.Instance().StartCoroutine(loader);
			this.sceneLoader = loader;
		}

		/// <summary>
		/// 释放法资源内部实现，只卸载不用资源
		/// </summary>
		public void Unload()
		{
			// 确保当前没有正在加载中的资源
			if (this.loadingResDict.Count != 0)
			{
				Debug.LogWarning("There is loading resource... cannot unload");
				return;
			}
			#if ASSETBUNDLE
			// 释放AssetBundle
			foreach (KeyValuePair<string, AssetBundleSceneLoader> sceneLoaderKV in this.loadedAssetBundleSceneLoaderDict)
			sceneLoaderKV.Value.Unload();
			foreach (KeyValuePair<string, AssetBundleLoader> loaderKV in this.loadedAssetBundleLoaderDict)
			loaderKV.Value.Unload();
			this.loadedAssetBundleSceneLoaderDict.Clear();
			this.loadedAssetBundleLoaderDict.Clear();
			#endif
			QApp.Instance().StartCoroutine(InternalUnloadAsync());
		}

		/// <summary>
		/// 异步释放资源内部实现
		/// </summary>
		/// <returns></returns>
		IEnumerator InternalUnloadAsync()
		{
			Debug.LogWarning ("Unload in ResMgr");

			AsyncOperation opt = Resources.UnloadUnusedAssets();
			yield return opt;
		}

		/// <summary>
		/// 添加到"正在"加载资源列表
		/// </summary>
		/// <param name="loader">加载器</param>
		void AddLoadingLoader(IResLoader loader)
		{
			

			QLog.Assert ((loader != null), "AddLoadingLoader loader is NULL");
			QLog.Assert (!this.loadingResDict.ContainsKey (loader.ResName), string.Format ("Already Loading {0}", loader.ResName));

			//Debug.Log(string.Format("{0} start loading at {1}", loader.ResName, Time.frameCount));
			this.loadingResDict[loader.ResName] = loader;
		}
	}

}
