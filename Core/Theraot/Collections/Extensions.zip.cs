﻿// <auto-generated />

using System;
using System.Collections.Generic;

using Theraot.Core;

namespace Theraot.Collections
{
    public static partial class Extensions
    {
#if NET20 || NET30 || NET35
        public static IEnumerable<TReturn> Zip<T1, T2, TReturn>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, TReturn> resultSelector)
#else
        public static IEnumerable<TReturn> Zip<T1, T2, TReturn>(IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, TReturn> resultSelector)
#endif
        {
            var _1 = Check.NotNullArgument(first, "arg1");
            var _2 = Check.NotNullArgument(second, "arg2");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, Func<T1, T2, T3, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, Func<T1, T2, T3, T4, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, Func<T1, T2, T3, T4, T5, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, Func<T1, T2, T3, T4, T5, T6, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, IEnumerable<T9> arg9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _9 = Check.NotNullArgument(arg9, "arg9");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            using (var enumerator9 = _9.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                    && enumerator9.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current,
                        enumerator9.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, IEnumerable<T9> arg9, IEnumerable<T10> arg10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _9 = Check.NotNullArgument(arg9, "arg9");
            var _10 = Check.NotNullArgument(arg10, "arg10");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            using (var enumerator9 = _9.GetEnumerator())
            using (var enumerator10 = _10.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                    && enumerator9.MoveNext()
                    && enumerator10.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current,
                        enumerator9.Current,
                        enumerator10.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, IEnumerable<T9> arg9, IEnumerable<T10> arg10, IEnumerable<T11> arg11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _9 = Check.NotNullArgument(arg9, "arg9");
            var _10 = Check.NotNullArgument(arg10, "arg10");
            var _11 = Check.NotNullArgument(arg11, "arg11");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            using (var enumerator9 = _9.GetEnumerator())
            using (var enumerator10 = _10.GetEnumerator())
            using (var enumerator11 = _11.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                    && enumerator9.MoveNext()
                    && enumerator10.MoveNext()
                    && enumerator11.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current,
                        enumerator9.Current,
                        enumerator10.Current,
                        enumerator11.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, IEnumerable<T9> arg9, IEnumerable<T10> arg10, IEnumerable<T11> arg11, IEnumerable<T12> arg12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _9 = Check.NotNullArgument(arg9, "arg9");
            var _10 = Check.NotNullArgument(arg10, "arg10");
            var _11 = Check.NotNullArgument(arg11, "arg11");
            var _12 = Check.NotNullArgument(arg12, "arg12");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            using (var enumerator9 = _9.GetEnumerator())
            using (var enumerator10 = _10.GetEnumerator())
            using (var enumerator11 = _11.GetEnumerator())
            using (var enumerator12 = _12.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                    && enumerator9.MoveNext()
                    && enumerator10.MoveNext()
                    && enumerator11.MoveNext()
                    && enumerator12.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current,
                        enumerator9.Current,
                        enumerator10.Current,
                        enumerator11.Current,
                        enumerator12.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, IEnumerable<T9> arg9, IEnumerable<T10> arg10, IEnumerable<T11> arg11, IEnumerable<T12> arg12, IEnumerable<T13> arg13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _9 = Check.NotNullArgument(arg9, "arg9");
            var _10 = Check.NotNullArgument(arg10, "arg10");
            var _11 = Check.NotNullArgument(arg11, "arg11");
            var _12 = Check.NotNullArgument(arg12, "arg12");
            var _13 = Check.NotNullArgument(arg13, "arg13");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            using (var enumerator9 = _9.GetEnumerator())
            using (var enumerator10 = _10.GetEnumerator())
            using (var enumerator11 = _11.GetEnumerator())
            using (var enumerator12 = _12.GetEnumerator())
            using (var enumerator13 = _13.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                    && enumerator9.MoveNext()
                    && enumerator10.MoveNext()
                    && enumerator11.MoveNext()
                    && enumerator12.MoveNext()
                    && enumerator13.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current,
                        enumerator9.Current,
                        enumerator10.Current,
                        enumerator11.Current,
                        enumerator12.Current,
                        enumerator13.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, IEnumerable<T9> arg9, IEnumerable<T10> arg10, IEnumerable<T11> arg11, IEnumerable<T12> arg12, IEnumerable<T13> arg13, IEnumerable<T14> arg14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _9 = Check.NotNullArgument(arg9, "arg9");
            var _10 = Check.NotNullArgument(arg10, "arg10");
            var _11 = Check.NotNullArgument(arg11, "arg11");
            var _12 = Check.NotNullArgument(arg12, "arg12");
            var _13 = Check.NotNullArgument(arg13, "arg13");
            var _14 = Check.NotNullArgument(arg14, "arg14");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            using (var enumerator9 = _9.GetEnumerator())
            using (var enumerator10 = _10.GetEnumerator())
            using (var enumerator11 = _11.GetEnumerator())
            using (var enumerator12 = _12.GetEnumerator())
            using (var enumerator13 = _13.GetEnumerator())
            using (var enumerator14 = _14.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                    && enumerator9.MoveNext()
                    && enumerator10.MoveNext()
                    && enumerator11.MoveNext()
                    && enumerator12.MoveNext()
                    && enumerator13.MoveNext()
                    && enumerator14.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current,
                        enumerator9.Current,
                        enumerator10.Current,
                        enumerator11.Current,
                        enumerator12.Current,
                        enumerator13.Current,
                        enumerator14.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, IEnumerable<T9> arg9, IEnumerable<T10> arg10, IEnumerable<T11> arg11, IEnumerable<T12> arg12, IEnumerable<T13> arg13, IEnumerable<T14> arg14, IEnumerable<T15> arg15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _9 = Check.NotNullArgument(arg9, "arg9");
            var _10 = Check.NotNullArgument(arg10, "arg10");
            var _11 = Check.NotNullArgument(arg11, "arg11");
            var _12 = Check.NotNullArgument(arg12, "arg12");
            var _13 = Check.NotNullArgument(arg13, "arg13");
            var _14 = Check.NotNullArgument(arg14, "arg14");
            var _15 = Check.NotNullArgument(arg15, "arg15");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            using (var enumerator9 = _9.GetEnumerator())
            using (var enumerator10 = _10.GetEnumerator())
            using (var enumerator11 = _11.GetEnumerator())
            using (var enumerator12 = _12.GetEnumerator())
            using (var enumerator13 = _13.GetEnumerator())
            using (var enumerator14 = _14.GetEnumerator())
            using (var enumerator15 = _15.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                    && enumerator9.MoveNext()
                    && enumerator10.MoveNext()
                    && enumerator11.MoveNext()
                    && enumerator12.MoveNext()
                    && enumerator13.MoveNext()
                    && enumerator14.MoveNext()
                    && enumerator15.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current,
                        enumerator9.Current,
                        enumerator10.Current,
                        enumerator11.Current,
                        enumerator12.Current,
                        enumerator13.Current,
                        enumerator14.Current,
                        enumerator15.Current
                    );
                }
            }
        }

        public static IEnumerable<TReturn> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn>(IEnumerable<T1> arg1, IEnumerable<T2> arg2, IEnumerable<T3> arg3, IEnumerable<T4> arg4, IEnumerable<T5> arg5, IEnumerable<T6> arg6, IEnumerable<T7> arg7, IEnumerable<T8> arg8, IEnumerable<T9> arg9, IEnumerable<T10> arg10, IEnumerable<T11> arg11, IEnumerable<T12> arg12, IEnumerable<T13> arg13, IEnumerable<T14> arg14, IEnumerable<T15> arg15, IEnumerable<T16> arg16, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> resultSelector)
        {
            var _1 = Check.NotNullArgument(arg1, "arg1");
            var _2 = Check.NotNullArgument(arg2, "arg2");
            var _3 = Check.NotNullArgument(arg3, "arg3");
            var _4 = Check.NotNullArgument(arg4, "arg4");
            var _5 = Check.NotNullArgument(arg5, "arg5");
            var _6 = Check.NotNullArgument(arg6, "arg6");
            var _7 = Check.NotNullArgument(arg7, "arg7");
            var _8 = Check.NotNullArgument(arg8, "arg8");
            var _9 = Check.NotNullArgument(arg9, "arg9");
            var _10 = Check.NotNullArgument(arg10, "arg10");
            var _11 = Check.NotNullArgument(arg11, "arg11");
            var _12 = Check.NotNullArgument(arg12, "arg12");
            var _13 = Check.NotNullArgument(arg13, "arg13");
            var _14 = Check.NotNullArgument(arg14, "arg14");
            var _15 = Check.NotNullArgument(arg15, "arg15");
            var _16 = Check.NotNullArgument(arg16, "arg16");
            var _result = Check.NotNullArgument(resultSelector, "resultSelector");
            using (var enumerator1 = _1.GetEnumerator())
            using (var enumerator2 = _2.GetEnumerator())
            using (var enumerator3 = _3.GetEnumerator())
            using (var enumerator4 = _4.GetEnumerator())
            using (var enumerator5 = _5.GetEnumerator())
            using (var enumerator6 = _6.GetEnumerator())
            using (var enumerator7 = _7.GetEnumerator())
            using (var enumerator8 = _8.GetEnumerator())
            using (var enumerator9 = _9.GetEnumerator())
            using (var enumerator10 = _10.GetEnumerator())
            using (var enumerator11 = _11.GetEnumerator())
            using (var enumerator12 = _12.GetEnumerator())
            using (var enumerator13 = _13.GetEnumerator())
            using (var enumerator14 = _14.GetEnumerator())
            using (var enumerator15 = _15.GetEnumerator())
            using (var enumerator16 = _16.GetEnumerator())
            {
                while
                (
                    enumerator1.MoveNext()
                    && enumerator2.MoveNext()
                    && enumerator3.MoveNext()
                    && enumerator4.MoveNext()
                    && enumerator5.MoveNext()
                    && enumerator6.MoveNext()
                    && enumerator7.MoveNext()
                    && enumerator8.MoveNext()
                    && enumerator9.MoveNext()
                    && enumerator10.MoveNext()
                    && enumerator11.MoveNext()
                    && enumerator12.MoveNext()
                    && enumerator13.MoveNext()
                    && enumerator14.MoveNext()
                    && enumerator15.MoveNext()
                    && enumerator16.MoveNext()
                )
                {
                    yield return _result
                    (
                        enumerator1.Current,
                        enumerator2.Current,
                        enumerator3.Current,
                        enumerator4.Current,
                        enumerator5.Current,
                        enumerator6.Current,
                        enumerator7.Current,
                        enumerator8.Current,
                        enumerator9.Current,
                        enumerator10.Current,
                        enumerator11.Current,
                        enumerator12.Current,
                        enumerator13.Current,
                        enumerator14.Current,
                        enumerator15.Current,
                        enumerator16.Current
                    );
                }
            }
        }
    }
}