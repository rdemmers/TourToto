using System;
using TourToto.Models;
using TourToto.Models.Builder;

namespace TourToto.DataTypes.Interfaces
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