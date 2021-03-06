﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Theraot.Threading.Needles
{
    [Serializable]
    [global::System.Diagnostics.DebuggerNonUserCode]
    public struct StructNeedle<T> : INeedle<T>, IEquatable<StructNeedle<T>>
    {
        private T _target;

        public StructNeedle(T target)
        {
            _target = target;
        }

        public bool IsAlive
        {
            get
            {
                return !ReferenceEquals(_target, null);
            }
        }

        public T Value
        {
            get
            {
                Thread.MemoryBarrier();
                return _target;
            }
            set
            {
                _target = value;
                Thread.MemoryBarrier();
            }
        }

        public static explicit operator T(StructNeedle<T> needle)
        {
            return needle.Value;
        }

        public static implicit operator StructNeedle<T>(T field)
        {
            return new StructNeedle<T>(field);
        }

        public static bool operator !=(StructNeedle<T> left, StructNeedle<T> right)
        {
            return NotEqualsExtracted(left, right);
        }

        public static bool operator ==(StructNeedle<T> left, StructNeedle<T> right)
        {
            return EqualsExtracted(left, right);
        }

        public override bool Equals(object obj)
        {
            if (obj is StructNeedle<T>)
            {
                return EqualsExtracted(this, (StructNeedle<T>)obj);
            }
            else
            {
                if (obj is T)
                {
                    var target = _target;
                    if (IsAlive)
                    {
                        return EqualityComparer<T>.Default.Equals(target, (T)obj);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Equals(StructNeedle<T> other)
        {
            return EqualsExtracted(this, other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        void INeedle<T>.Free()
        {
            _target = default(T);
        }

        public override string ToString()
        {
            var target = Value;
            if (IsAlive)
            {
                return target.ToString();
            }
            else
            {
                return "<Dead Needle>";
            }
        }

        private static bool EqualsExtracted(StructNeedle<T> left, StructNeedle<T> right)
        {
            var _left = left.Value;
            if (left.IsAlive)
            {
                var _right = right.Value;
                return right.IsAlive && EqualityComparer<T>.Default.Equals(_left, _right);
            }
            else
            {
                return !right.IsAlive;
            }
        }

        private static bool NotEqualsExtracted(StructNeedle<T> left, StructNeedle<T> right)
        {
            var _left = left.Value;
            if (left.IsAlive)
            {
                var _right = right.Value;
                return !right.IsAlive || !EqualityComparer<T>.Default.Equals(_left, _right);
            }
            else
            {
                return right.IsAlive;
            }
        }
    }
}