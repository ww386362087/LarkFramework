using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

namespace LarkFramework.Test
{
    public class SingletonReflex<T> : MonoBehaviour where T : SingletonReflex<T>
    {
        protected static T instance = null;

        protected SingletonReflex()
        {
        }

        public static T Instance()
        {
            if (instance == null)
            {
                //为了可以被继承,静态实例和构造方法都使用protect修饰符。以上的问题很显而易见,那就是不能new一个泛型(3月9日补充:并不是不能new一个泛型,参考:http://bbs.csdn.net/topics/390911693 ),(4月5日补充:有同学说可以new一个泛型的实例,不过要求改泛型提供了public的构造函数,好吧,这里不用new的原因是,无法显示调用private的构造函数)

                // 先获取所有非public的构造方法
                ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                // 从ctors中获取无参的构造方法
                ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null)
                    throw new Exception("Non-public ctor() not found!");
                // 调用构造方法
                instance = ctor.Invoke(null) as T;
            }

            return instance;
        }

        public virtual void Init()
        {
            return;
        }

        public virtual void Release()
        {
            return;
        }
    }
}
