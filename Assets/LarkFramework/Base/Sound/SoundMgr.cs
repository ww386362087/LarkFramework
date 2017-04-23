/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2017-04-23 22:31:23
 * 修改：evesgf    修改时间：2017-04-23 22:31:27
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：声音管理类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework.Sound
{
    public class SoundMgr : SingletonMono<SoundMgr>
    {
        /// <summary>
        /// 用来播放循环的背景音乐
        /// </summary>
        [SerializeField]
        private AudioSource bgmAudioSource;

        /// <summary>
        /// 特效的音乐
        /// </summary>
        [SerializeField]
        private AudioSource effectAudioSource;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            bgmAudioSource.loop = true;
            bgmAudioSource.playOnAwake = true;

            effectAudioSource.loop = false;
            effectAudioSource.playOnAwake = false;
        } 

        #region 背景音乐 2017-04-23 22:33:44
        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="clip"></param>
        public void PlayBgMusic(AudioClip clip)
        {
            if (clip == null)
                return;

            bgmAudioSource.clip = clip;
            bgmAudioSource.Play();
        }

        /// <summary>
        /// 背景音乐的音量
        /// </summary>
        public float BGVolume
        {
            get { return bgmAudioSource.volume; }
            set { bgmAudioSource.volume = value; }
        }

        /// <summary>
        /// 停止背景音乐的播放
        /// </summary>
        public void StopBgMusic()
        {
            bgmAudioSource.clip = null;
            bgmAudioSource.Stop();
        }
        #endregion

        #region 特效音乐 2017-04-23 22:33:39
        public void PlayEffectMusic(AudioClip clip)
        {
            if (clip == null)
                return;

            effectAudioSource.clip = clip;
            effectAudioSource.Play();
        }
        #endregion
    }
}
