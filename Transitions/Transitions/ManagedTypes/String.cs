﻿using System;

namespace Transitions.ManagedTypes
{
    /// <summary>
    /// Manages transitions for strings. This doesn't make as much sense as transitions
    /// on other types, but I like the way it looks!
    /// </summary>
    internal class String : IManagedType
    {
        #region IManagedType Members

        /// <summary>
        /// Returns the type we're managing.
        /// </summary>
        public Type GetManagedType()
        {
            return typeof(string);
        }

        /// <summary>
        /// Returns a copy of the string passed in.
        /// </summary>
        public object Copy(object o)
        {
            var s = (string)o;
            return new string(s.ToCharArray());
        }

        /// <summary>
        /// Returns an "interpolated" string.
        /// </summary>
        public object GetIntermediateValue(object start, object end, double dPercentage)
        {
            var strStart = (string)start;
            var strEnd = (string)end;

            // We find the length of the interpolated string...
            int iStartLength = strStart.Length;
            int iEndLength = strEnd.Length;
            int iLength = Utility.Interpolate(iStartLength, iEndLength, dPercentage);
            var result = new char[iLength];

            // Now we assign the letters of the results by interpolating the
            // letters from the start and end strings...
            for (int i = 0; i < iLength; ++i)
            {
                // We get the start and end chars at this position...
                char cStart = 'a';
                if (i < iStartLength)
                {
                    cStart = strStart[i];
                }
                char cEnd = 'a';
                if (i < iEndLength)
                {
                    cEnd = strEnd[i];
                }

                // We interpolate them...
                char cInterpolated;
                if (cEnd == ' ')
                {
                    // If the end character is a space we just show a space 
                    // regardless of interpolation. It looks better this way...
                    cInterpolated = ' ';
                }
                else
                {
                    // The end character is not a space, so we interpolate...
                    int iStart = Convert.ToInt32(cStart);
                    int iEnd = Convert.ToInt32(cEnd);
                    int iInterpolated = Utility.Interpolate(iStart, iEnd, dPercentage);
                    cInterpolated = Convert.ToChar(iInterpolated);
                }

                result[i] = cInterpolated;
            }

            return new string(result);
        }

        #endregion
    }
}
