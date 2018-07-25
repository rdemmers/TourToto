using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;

namespace TourToto.Builder
{
    class DayBuilder
    {
        private int dayId;
        private String startingPoint;
        private String endPoint;
        private DateTime date;
        private double length;
        private String description;
        private int placementId;

        public DayBuilder setDayId(int dayId)
        {
            this.dayId = dayId;
            return this;
        }

        public DayBuilder setStartingPoint(String startingPoint)
        {
            this.startingPoint = startingPoint;
            return this;
        }

        public DayBuilder setEndPoint(String endPoint)
        {
            this.endPoint = endPoint;
            return this;
        }

        public DayBuilder setDate(DateTime date)
        {
            this.date = date;
            return this;
        }

        public DayBuilder setLength(double length)
        {
            this.length = length;
            return this;
        }

        public DayBuilder setDescription(String description)
        {
            this.description = description;
            return this;
        }

        public DayBuilder setPlacementId(int placementId)
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
