
namespace MeetingRoomPlanner.Entities
{
    /// <summary>
    /// Meeting room
    /// </summary>
    internal class MeetingRoom
    {
        #region Properties
        /// <summary>Available time slots</summary>
        internal List<TimeSlot> AvailableTimeSlots { get; set; } = new List<TimeSlot>();

        /// <summary>Booked time slots</summary>
        internal List<TimeSlot> BookedTimeSlots { get; set; } = new List<TimeSlot>();
        #endregion
    }
}
