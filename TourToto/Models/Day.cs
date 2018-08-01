using System;

namespace TourToto.Models
{
    public class Day
    {
        private int dayId;
        private String startingPoint;
        private String endPoint;
        private DateTime date;
        private double length;
        private String description;
        private int placementId;

        public Day()
        {
        }

        public Day(int dayId, string startingPoint, string endPoint, DateTime date, double length, string description, int placementId)
        {
            this.dayId = dayId;
            this.startingPoint = startingPoint;
            this.endPoint = endPoint;
            this.date = date;
            this.length = length;
            this.description = description;
            this.placementId = placementId;
        }
    }
}