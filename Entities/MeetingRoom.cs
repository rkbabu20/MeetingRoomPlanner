
namespace MeetingRoomPlanner.Entities
{
    /// <summary>
    /// Meeting room
    /// </summary>
    internal class MeetingRoom
    {
        #region constructor
        /// <summary>
        /// Meeting room initializer
        /// </summary>
        internal MeetingRoom() 
        {
            AvailableTimeSlots = new List<TimeSlot>();
            BookedTimeSlots = new List<TimeSlot>();
        }
        #endregion

        #region Properties
        /// <summary>Available time slots</summary>
        internal List<TimeSlot> AvailableTimeSlots { get; set; }

        /// <summary>Booked time slots</summary>
        internal List<TimeSlot> BookedTimeSlots { get; set; }
        #endregion
    }
}
