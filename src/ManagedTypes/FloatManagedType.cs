﻿using System;

namespace Forms.Transitions.ManagedTypes
{
    internal class FloatManagedType : IManagedType
    {
        #region IManagedType Members

        /// <summary>
        /// Returns the type we're managing.
        /// </summary>
        public Type GetManagedType() => typeof(float);

        /// <summary>
        /// Returns a copy of the float passed in.
        /// </summary>
        public object Copy(object o) => (float)o;

        /// <summary>
        /// Returns the interpolated value for the percentage passed in.
        /// </summary>
        public object GetIntermediateValue(object start, object end, double dPercentage)
        {
            var fStart = (float)start;
            var fEnd = (float)end;
            return Utility.Interpolate(fStart, fEnd, dPercentage);
        }

        #endregion
    }
}
