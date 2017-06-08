using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MethodInjector.Net
{
    public class MethodInjector
    {
        public static void Install<TTar, TInj>(string targetMethodName, string injectionMethodName)
        {
            MethodInfo targetMethod = typeof(TTar).GetMethod(targetMethodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            MethodInfo injectionMethod = typeof(TInj).GetMethod(injectionMethodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            RuntimeHelpers.PrepareMethod(targetMethod.MethodHandle);
            RuntimeHelpers.PrepareMethod(injectionMethod.MethodHandle);

            unsafe
            {
                if (IntPtr.Size == 4)
                {
                    int* tar = (int*)targetMethod.MethodHandle.Value.ToPointer() + 2;
                    int* inj = (int*)injectionMethod.MethodHandle.Value.ToPointer() + 2;
#if DEBUG
                    byte* injInst = (byte*)*inj;
                    byte* tarInst = (byte*)*tar;

                    int* injSrc = (int*)(injInst + 1);
                    int* tarSrc = (int*)(tarInst + 1);

                    *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
#else
                    *tar = *inj;
#endif
                }
                else
                {

                    long* tar = (long*)targetMethod.MethodHandle.Value.ToPointer()+1;
                    long* inj = (long*)injectionMethod.MethodHandle.Value.ToPointer()+1;
#if DEBUG
                    byte* injInst = (byte*)*inj;
                    byte* tarInst = (byte*)*tar;

                    int* injSrc = (int*)(injInst + 1);
                    int* tarSrc = (int*)(tarInst + 1);

                    *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
#else
                    *tar = *inj;
#endif
                }
            }
        }
    }
}
