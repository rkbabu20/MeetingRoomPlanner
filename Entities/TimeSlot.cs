namespace MeetingRoomPlanner.Entities
{
    /// <summary>
    /// Time slot
    /// </summary>
    /// <param name="startMinutes">Start minutes</param>
    /// <param name="endMinutes">End Minutes</param>
    public class TimeSlot(int startMinutes, int endMinutes)
    {
        #region Properties
        /// <summary>Start Minutes</summary>
        public int StartMinutes { get; set; } = startMinutes;
        /// <summary>End Minutes</summary>
        public int EndMinutes { get; set; } = endMinutes;
        /// <summary>Duration Minutes</summary>
        public int DurationMinutes => (EndMinutes - StartMinutes);
        #endregion
    }
}
