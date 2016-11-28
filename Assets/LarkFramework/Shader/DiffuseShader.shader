Shader "Custom/DiffuseShader" {

	// Properties用来定义着色器属性，属性将作为输入提供给子着色器
	// 语法：
	//		_Name("Display Name", type) = defaultValue[{options}]
	//		变量名("面板说明文字", 类型) = 默认值[{选项}]
	// type：
	//		·Color：RGBA色值
	//		·2D：2阶尺寸（256,512等）的贴图，采样后转为对应基于模型UV的每个像素颜色并显示
	//		·Rect：非二阶数大小的贴图
	//		·Cube：即Cube map texture（立方体纹理），简单说就是6张有联系的2D贴图的组合，
	//		主要用来做反射效果（比如天空盒和动态反射），也会被转换为对应点的采样；
	//		·Range：截取数值范围Range(main,max)
	//		·Float：浮点数
	//		·Vector：四维数
	// {option}：
	//		只对2D，Rect或者Cube贴图有关，在写输入时我们最少要在贴图之后写一对什么都不含的
	//		空白的{}，当我们需要打开特定选项时可以把其写在这对花括号内。如果需要同时打开多
	//		个选项，可以使用空白分隔。可能的选择有ObjectLinear, EyeLinear, SphereMap, 
	//		CubeReflect, CubeNormal中的一个，这些都是OpenGL中TexGen的模式。注意，如果你编
	//		写了一个顶点函数，那么可以忽略TexGen。
	//		Color：使用浮点值表示的(r, g, b, a)，例如(1,1,1,1)；
	//		2D/Rect/Cube：默认值可为空字符串，或"white", "black", "gray", "bump"等字符串；
	//		Float / Range：在此范围内的值即可；
	//		Vector：以(x, y, z, w)形式表示的4D向量；
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}

	SubShader {

		// 硬件通过Tags决定何时调用该着色器，暗示输出结果
		// ·"RenderType"="Opaque"：渲染非透明物体时调用
		// ·"RenderType" = "Transparent"：渲染透明物体时调用
		// ·"IgnoreProjector" = "True"：不被Projectors影响
		// ·"ForceNoShadowCasting" = "True"：从不产生阴影
		// ·"Queue" = "xxx"：指定渲染顺序队列
		// 如果你使用Unity做过一些透明和不透明物体的混合的话，很可能已经遇到过不透明物体无
		// 法呈现在透明物体之后的情况。这种情况很可能是由于Shader的渲染顺序不正确导致的。
		// Queue指定了物体的渲染顺序，预定义的Queue有：
		// Background - 最早被调用的渲染，用来渲染天空盒或者背景
		// Geometry - 这是默认值，用来渲染非透明物体（普通情况下，场景中的绝大多数物体应该是非透明的）
		// AlphaTest - 用来渲染经过Alpha Test的像素，单独为AlphaTest设定一个Queue是出于对效率的考虑
		// Transparent - 以从后往前的顺序渲染透明物体
		// Overlay - 用来渲染叠加的效果，是渲染的最后阶段（比如镜头光晕等特效）
		// 这些预定义的值本质上是一组定义整数，Background = 1000，Geometry = 2000
		// AlphaTest = 2450， Transparent = 3000，最后Overlay = 4000。在我们实际设置Queue值
		// AlphaTest = 2450， Transparent = 3000，最后Overlay = 4000。在我们实际设置Queue值
		// 时，不仅能使用上面的几个预定义值，我们也可以指定自己的Queue值，写成类似这样：
		// "Queue" = "Transparent+100"，表示一个在Transparent之后100的Queue上进行调用。通过
		// 调整Queue值，我们可以确保某些物体一定在另一些物体之前或者之后渲染。
		Tags { "RenderType"="Opaque" }

		// 当设定的LOD小于SubShader所指定的LOD时，这个SubShader将不可用
		// Unity内建Lod值：
		// ·VertexLit及其系列 = 100
		// ·Decal, Reflective VertexLit = 150
		// ·Diffuse = 200
		// ·Diffuse Detail, Reflective Bumped Unlit, Reflective Bumped VertexLit = 250
		// ·Bumped, Specular = 300
		// ·Bumped Specular = 400
		// ·Parallax = 500
		// ·Parallax Specular = 600
		LOD 200
		
		// CGPROGRAM是开始标记，表明从这里开始一段CG程序（Cg/HLSL语言）
		// 与最后一行的ENDCG对应，表明CG程序到此结束。
		CGPROGRAM

		// 编译指令，声明脚本为表面Shader，并指定光照模型
		// 语法：
		// #pragma surface surfaceFunction lightModel [optionalparams]
		// #pragma 声明着色器类型 着色器代码方法名 光照模型 [optionalparams]
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		// sampler2D是个啥？其实在CG中，sampler2D就是和texture所绑定的一个数据容器接口。等等..这个
		// 说法还是太复杂了，简单理解的话，所谓加载以后的texture（贴图）说白了不过是一块内存存储的，
		// 使用了RGB（也许还有A）通道，且每个通道8bits的数据。而具体地想知道像素与坐标的对应关系，
		// 以及获取这些数据，我们总不能一次一次去自己计算内存地址或者偏移，因此可以通过sampler2D来
		// 对贴图进行操作。更简单地理解，sampler2D就是GLSL中的2D贴图的类型，相应的，还有sampler1D，
		// sampler3D，samplerCube等等格式
		// 解释通了sampler2D是什么之后，还需要解释下为什么在这里需要一句对_MainTex的声明，之前我们
		// 不是已经在Properties里声明过它是贴图了么。答案是我们用来实例的这个shader其实是由两个相对
		// 独立的块组成的，外层的属性声明，回滚等等是Unity可以直接使用和编译的ShaderLab；而现在我们
		// 是在CGPROGRAM...ENDCG这样一个代码块中，这是一段CG程序。对于这段CG程序，要想访问在
		// Properties中所定义的变量的话，必须使用和之前变量相同的名字进行声明。于是其实sampler2D 
		// _MainTex;做的事情就是再次声明并链接了_MainTex，使得接下来的CG程序能够使用这个变量。
		sampler2D _MainTex;

		// 声明输入的结构体，规范约束必须名为Input
		// float和Vec后都可跟2-4，表示被打包到一起的2-4个同类型函数
		// 可用名称获取整组值，也可用下标.xyzw等方式获取单个值
		// 规范约束在贴图变量前加UV字母，表示提取UV值
		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// 计算输出时Shader会多次调用surf函数，每次给入一个贴图上的点坐标来计算输出
		// SurfaceOutput可选，预定义输出结构
		// struct SurfaceOutput {
		//		half3 Albedo;     //像素的颜色
		//		half3 Normal;     //像素的法向值
		//		half3 Emission;   //像素的发散颜色
		//		half Specular;    //像素的镜面高光
		//		half Gloss;       //像素的发光强度
		//		half Alpha;       //像素的透明度
		// };
		// half指半精度浮点数，相对性能较高
		// tex2d函数用来在一张贴图中对一个点进行采样的方法，返回float4
		void surf (Input IN, inout SurfaceOutputStandard o) {
			// 对_MainTex在输入点上进行了采样，并将其颜色的rbg值赋予了输出的像素颜色，将a值赋予透明度
			// 即找到贴图上对应的uv点，直接使用颜色信息来进行着色
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
