using System;
using TourToto.Model;

namespace TourToto.Builder
{
    internal interface IDayBuilder
    {
        Day build();

        DayBuilder SetDate(DateTime date);

        DayBuilder SetDayId(int dayId);

        DayBuilder SetDescription(string description);

        DayBuilder SetEndPoint(string endPoint);

        DayBuilder SetLength(double length);

        DayBuilder SetPlacementId(int placementId);

        DayBuilder SetStartingPoint(string startingPoint);
    }
}