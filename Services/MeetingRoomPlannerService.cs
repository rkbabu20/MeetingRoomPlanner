using MeetingRoomPlanner.Entities;
using MeetingRoomPlanner.Extensions;
using MeetingRoomPlanner.Repository;

namespace MeetingRoomPlanner.Services
{
    /// <summary>
    /// Meeting room planner service
    /// </summary>
    internal class MeetingRoomPlannerService
    {
        #region private variables
        private readonly DataRepository _repository;
        #endregion

        #region Constructor
        public MeetingRoomPlannerService() 
        {
            // Initialize repository
            _repository = new DataRepository();
        }
        #endregion

        #region internal methods
        /// <summary>
        /// Get meeting rooms with schedules
        /// </summary>
        /// <param name="rawTimeSlots"></param>
        /// <returns></returns>
        internal MeetingRoomsResponse ScheduleMeetings(int[][] rawTimeSlots)
        {
            var response = new MeetingRoomsResponse();
            try
            {
                int minStartMins, maxEndMins = 0;
                //Step 1 : Check if given input is valid
                if (rawTimeSlots.IsValidInput(response.Errors))
                {
                    // Step 2 : Determine minimum and maximum timeminues across all the time slots to generate estimated rooms;
                    rawTimeSlots.DetermineMinimumAndMaxTimeSlotDuration(out minStartMins, out maxEndMins);
                    // Step 3 : Convert array input to timeslots entity list
                    var timeSlotsList = _repository.GetTimeSlots(rawTimeSlots);
                    // Step 4 : Generate estimated number of rooms
                    response.MeetingRooms = BookMeetingRooms(timeSlotsList, minStartMins, maxEndMins);
                    // Step 5 : Set success if no errors
                    response.IsSuccess = !response.Errors.Any();
                }
            }
            catch(Exception ex) 
            {
                response.Errors.Add(ex.Message);
                response.Errors.Add(ex.StackTrace!);
            }
            return response;
        }// End GetMeetingRoomsWithSchedule
        #endregion

        #region Private methods
        /// <summary>
        /// Book meeting rooms for all time slots
        /// </summary>
        /// <param name="timeSlots">Time slots list to book</param>
        /// <param name="minStartMins"></param>
        /// <param name="maxEndMins"></param>
        /// <returns></returns>
        private List<MeetingRoom> BookMeetingRooms(List<TimeSlot> timeSlots,int minStartMins, int maxEndMins) 
        { 
            var meetingRooms = new List<MeetingRoom>();
            // Step 1 : Create a meeting room with default start time and end time as available slot
            var meetingRoom = _repository.CreateMeetingRoomWithDefaultMinutes(minStartMins, maxEndMins);
            var timeSlotsNotBooked = new List<TimeSlot>();
            foreach (var timeSlot in timeSlots)
            {
                // Step 2 : Foreach timeslot to book, check if meeting room can be accomodated 
                if (meetingRoom.HasAvailableTimeSlot(timeSlot))
                    meetingRoom.ScheduleMeeting(timeSlot); // If yes then schedule the meeting
                else // If not then add to new list for not booked timeslots
                    timeSlotsNotBooked.Add(timeSlot);
            }
            // Step 3 : If timeslots booked then add to meetingrooms
            if (meetingRoom.BookedTimeSlots.Any())
                meetingRooms.Add(meetingRoom);
            if(timeSlotsNotBooked.Any())
            {
                // Step 4 : Call this method recursively for non unbooked timeslots
                var newMeetingRooms = BookMeetingRooms(timeSlotsNotBooked,minStartMins, maxEndMins);
                if (newMeetingRooms.Any())
                    meetingRooms.AddRange(newMeetingRooms);
            }
            return meetingRooms;
        }// End BookMeetingRooms
        #endregion
    }
}
