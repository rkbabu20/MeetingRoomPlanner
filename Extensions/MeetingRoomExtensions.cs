using MeetingRoomPlanner.Entities;

namespace MeetingRoomPlanner.Extensions
{
    /// <summary>
    /// Meeting room extensions class
    /// </summary>
    internal static class MeetingRoomExtensions
    {
        #region Meeting room extension methods
        /// <summary>
        /// Check if meeting room has available timeslots
        /// </summary>
        /// <param name="meetingRoom">MeetingRoom</param>
        /// <param name="timeSlot">TimeSlot</param>
        /// <returns>True : If time slot is available for booking.</returns>
        internal static bool HasAvailableTimeSlot(this MeetingRoom meetingRoom, TimeSlot timeSlot)
        {
            return meetingRoom != null
                      && timeSlot != null
                      && meetingRoom.AvailableTimeSlots.Any()
                      && meetingRoom.GetMatchingAvailableTimeSlot(timeSlot) != null;
        }

        /// <summary>
        /// Schedule meeting
        /// </summary>
        /// <param name="meetingRoom">MeetingRoom</param>
        /// <param name="timeSlot">TimeSlot</param>
        internal static void ScheduleMeeting(this MeetingRoom meetingRoom, TimeSlot timeSlot)
        {
            if (meetingRoom != null && timeSlot != null)
            {
                // Step 1 : Schedule meeting
                meetingRoom.BookedTimeSlots.Add(timeSlot);
                // Step 2 : Split available timeslots
                meetingRoom.SplitBookedAvailableTimeSlot(timeSlot);
            }
        }

        /// <summary>
        /// Print schedule
        /// </summary>
        /// <param name="timeSlot"></param>
        internal static void PrintSchedule(this MeetingRoom meetingRoom)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"Number of bookings on this room : {meetingRoom.BookedTimeSlots.Count} ");
            meetingRoom.BookedTimeSlots.ForEach(timeSlot => Console.WriteLine($"Booking Schedule StartMinutes: {timeSlot.StartMinutes}, EndMinutes: {timeSlot.EndMinutes}"));
        }

        #endregion

        #region Private methods
        private static void SplitBookedAvailableTimeSlot(this MeetingRoom meetingRoom, TimeSlot timeSlot)
        {
            if (meetingRoom != null && timeSlot != null)
            {
                // Get Booked time slot from available timeslots
                var bookedTimeSlot = meetingRoom.GetMatchingAvailableTimeSlot(timeSlot);
                if (bookedTimeSlot != null)
                {
                    // Remove booked time slot from the meeting room's available timeslot
                    meetingRoom.AvailableTimeSlots.RemoveAll(x => x.StartMinutes == bookedTimeSlot?.StartMinutes && x.EndMinutes == bookedTimeSlot?.EndMinutes);

                    // Add time slots for unbooked part of the duration as available timeslots for further bookings.
                    /* Case 1 : Below case no split needed.
                     * |-----------------------| Available time slot
                     * |-----------------------| booked part of the the timeslot
                    */

                    /* Case 2 : Below case will result in to one time slot to be added to available timeslots.
                     * |-----------------------| Available time slot
                     * |------------| booked part of the the timeslot
                    */
                    if (bookedTimeSlot?.StartMinutes == timeSlot.StartMinutes && bookedTimeSlot.EndMinutes > timeSlot.EndMinutes)
                        meetingRoom.AvailableTimeSlots.Add(new TimeSlot(timeSlot.EndMinutes, bookedTimeSlot.EndMinutes));

                    /* Case 3 : Below case will result to one time slot to be added to available timeslots.
                     * |-----------------------| Available time slot
                     *            |------------| booked part of the the timeslot
                    */
                    if (bookedTimeSlot?.EndMinutes == timeSlot.EndMinutes && bookedTimeSlot.StartMinutes < timeSlot.StartMinutes)
                        meetingRoom.AvailableTimeSlots.Add(new TimeSlot(bookedTimeSlot.StartMinutes, timeSlot.StartMinutes));

                    /* Case 4 : Below case will result in to two time slots to be added to available timeslots.
                     * |-----------------------| Available time slot
                     *       |------------| booked part of the the timeslot
                    */
                    if (bookedTimeSlot?.StartMinutes < timeSlot.StartMinutes && bookedTimeSlot.EndMinutes > timeSlot.EndMinutes)
                    {
                        meetingRoom.AvailableTimeSlots.Add(new TimeSlot(bookedTimeSlot.StartMinutes, timeSlot.StartMinutes));
                        meetingRoom.AvailableTimeSlots.Add(new TimeSlot(timeSlot.EndMinutes, bookedTimeSlot.EndMinutes));
                    }
                }
            }
        }

        private static TimeSlot? GetMatchingAvailableTimeSlot(this MeetingRoom meetingRoom, TimeSlot timeSlotToBook)
        {
            return meetingRoom.AvailableTimeSlots
                .Find(availableSlot =>
                        (availableSlot.StartMinutes <= timeSlotToBook.StartMinutes)
                        && (availableSlot.EndMinutes >= timeSlotToBook.EndMinutes));
        }
        #endregion

    }

}
