using GbLib.Extensions;

namespace GbLib.Base.Helpers
{
    public static class CoordinateHelper
    {
        public static double distanceBetweenTwoPoint(
            double srcLat,
            double srcLng,
            double desLat,
            double desLng,
            double _distanceRateGps,
            bool isOffCoefficient
        )
        {
            if (isOriginLocation(srcLat, srcLng) || isOriginLocation(desLat, desLng))
            {
                return 0.0;
            }
            var distanceRateGps = _distanceRateGps;
            if (distanceRateGps > 0.5)
            {
                distanceRateGps = 0.5;
            }
            double earthRadius = 3958.75;
            double dLat = (desLat - srcLat).ToRadians();
            double dLng = (desLng - srcLng).ToRadians();
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                   + (Math.Cos(srcLat.ToRadians())
                   * Math.Cos(desLat.ToRadians()) * Math.Sin(dLng / 2)
                   * Math.Sin(dLng / 2));
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double dist = earthRadius * c;
            double meterConversion = 1609.0;
            var distanceTotal = dist * meterConversion;
            if (!distanceTotal.IsNumeric())
            {
                return 0.0;
            }
            if (!isOffCoefficient)
            {
                distanceTotal += (distanceRateGps > 0) ? (distanceTotal * distanceRateGps) : (distanceTotal * 0.1);
            }

            if (distanceTotal > 79.16)
            { // Nhiễu GPS or cấu hình quá lớn
                return 79.16;
            }
            return distanceTotal;
        }

        private static bool isOriginLocation(double? lat, double? lng)
        {
            if (lat == null || lng == null)
            {
                return true;
            }
            else
            {
                return lat == 0.0 || lng == 0.0;
            };
        }
    }
}