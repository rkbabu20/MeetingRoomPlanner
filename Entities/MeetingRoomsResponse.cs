using MeetingRoomPlanner.Extensions;

namespace MeetingRoomPlanner.Entities
{
    /// <summary>
    /// Meeting rooms response
    /// </summary>
    internal class MeetingRoomsResponse
    {
        #region Properties
        /// <summary>True: If success</summary>
        internal bool IsSuccess { get; set; }
        /// <summary>Meeting rooms booked</summary>
        internal List<MeetingRoom> MeetingRooms { get; set; } = new List<MeetingRoom>();
        
        /// <summary>Errors</summary>
        internal List<string> Errors { get; set; } = new List<string>();
        #endregion

        #region Internal methods
        /// <summary>
        /// Success response to print
        /// </summary>
        internal void PrintSuccessResponse()
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"All timeslots scheduled. {MeetingRooms.Count} meeting rooms booked");
            MeetingRooms.ForEach(room => room.PrintSchedule());
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        /// <summary>
        /// Print failed
        /// </summary>
        internal void PrintFailureResponse()
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"Bookings failed with following errors : {string.Join(',', Errors)}");
            Console.WriteLine("-------------------------------------------------------------------------");
        }
        #endregion
    }
}
