
using MeetingRoomPlanner.Services;
namespace MeetingRoomPlanner
{
    // Problem statement : If list of intervals are given in array of array format then get minimum number of meeting rooms to schedule all meetings without overlap.
    /// <summary>
    /// Program 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry point to the console application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Step 1 : Title
            Console.WriteLine("<--- M E E T I N G  R O O M S  S C H E D U L E R --->");

            // Step 2 : Initialize the service
            var service = new MeetingRoomPlannerService();

            // Step 3 : Schedule time slots
            var response = service.ScheduleMeetings(GetTestDataInput());

            // Step 4 : Write Success/Failure
            if (response.IsSuccess)
                response.PrintSuccessResponse();
            else
                response.PrintFailureResponse();

            // Step 5 : Exit logic
            Console.Write("Enter any key to exit:");
            Console.Read();
        }

        #region Test data input 
        /// <summary>
        /// Test data input
        /// </summary>
        /// <returns></returns>
        static int[][] GetTestDataInput()
        {
            return new int[][]
            {
                [1,30],  // First meeting timeslot
                [10,15], // Second meetting timeslot
                [13,20], // Third meeting timeslot
                [15,20], // 4th meeting timeslot
                [20,45],  // 4th meeting timeslot

                // Additiona slots for testing purpose
                [30,35],
                [35,40],
                [1,5],
            };
        }
        #endregion
    }
}
