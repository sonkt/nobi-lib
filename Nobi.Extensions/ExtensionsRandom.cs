namespace Nobi.Extensions
{
    using System;

    /// <summary>
    /// Defines the <see cref="ExtensionsRandom" />.
    /// </summary>
    public static class ExtensionsRandom
    {
        #region Methods

        public static double NextGaussian(this Random r, double average = 0, double deviation = 1)
        {
            double u1 = r.NextDouble();
            double u2 = r.NextDouble();

            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                  Math.Sin(2.0 * Math.PI * u2);

            double randNormal = average + deviation * randStdNormal;

            return randNormal;
        }

        #endregion Methods
    }
}