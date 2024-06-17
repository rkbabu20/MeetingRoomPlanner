using MeetingRoomPlanner.Entities;

namespace MeetingRoomPlanner.Repository
{
    /// <summary>
    /// Data repository
    /// </summary>
    internal class DataRepository
    {
        #region Internal methods
        /// <summary>
        /// Convert time slots array in to timeslot entities and sort them by total duration
        /// </summary>
        /// <param name="timeSlotsArray"></param>
        /// <returns>Time slots list</returns>
        internal List<TimeSlot> GetTimeSlots(int[][] timeSlotsArray)
        {
            var timeSlots = new List<TimeSlot>();
            if (timeSlotsArray != null && timeSlotsArray.Length > 0)
                timeSlots = timeSlotsArray.ToList().Select(arrayItem => new TimeSlot(arrayItem[0], arrayItem[1])).OrderByDescending(x=>x.DurationMinutes).ToList();
            return timeSlots;
        }


        /// <summary>
        /// Create meeting room with default minutes
        /// </summary>
        /// <param name="startMinutes"></param>
        /// <param name="endMinutes"></param>
        /// <returns>Meeting Room</returns>
        internal MeetingRoom CreateMeetingRoomWithDefaultMinutes(int startMinutes, int endMinutes)
        {
            return new MeetingRoom() { AvailableTimeSlots = { new TimeSlot(startMinutes, endMinutes) } };
        }
        #endregion
    }
}
