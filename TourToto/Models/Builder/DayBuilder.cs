using System;
using TourToto.DataTypes.Interfaces;

namespace TourToto.Models.Builder
{
    internal class DayBuilder : IDayBuilder
    {
        private int dayId;
        private String startingPoint;
        private String endPoint;
        private DateTime date;
        private double length;
        private String description;
        private int placementId;

        public DayBuilder SetDayId(int dayId)
        {
            this.dayId = dayId;
            return this;
        }

        public DayBuilder SetStartingPoint(String startingPoint)
        {
            this.startingPoint = startingPoint;
            return this;
        }

        public DayBuilder SetEndPoint(String endPoint)
        {
            this.endPoint = endPoint;
            return this;
        }

        public DayBuilder SetDate(DateTime date)
        {
            this.date = date;
            return this;
        }

        public DayBuilder SetLength(double length)
        {
            this.length = length;
            return this;
        }

        public DayBuilder SetDescription(String description)
        {
            this.description = description;
            return this;
        }

        public DayBuilder SetPlacementId(int placementId)
        {
            this.placementId = placementId;
            return this;
        }

        public Day build()
        {
            return new Day(dayId, startingPoint, endPoint, date, length, description, placementId);
        }
    }
}