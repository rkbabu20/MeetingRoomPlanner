namespace MeetingRoomPlanner.Extensions
{
    /// <summary>
    /// Time slot extensions
    /// </summary>
    internal static class TimeSlotArrayExtensions
    {
        #region Extension methods
        
        /// <summary>
        /// Validate the input
        /// </summary>
        /// <param name="timeSlotsArray">Timeslots array</param>
        /// <param name="validationErrors">Validation errors</param>
        /// <returns>true if the input is valid</returns>
        internal static bool IsValidInput(this int[][] timeSlotsArray, List<string> validationErrors)
        {
            if (validationErrors == null)
                validationErrors = new List<string>();
            // Step 1 : Check if timeslots array isnull
            if (timeSlotsArray == null)
                validationErrors.Add("Timeslots array is null. Provide valid input.");
            else
            {
                // Step 2 : Check if timeslots array have values
                if (timeSlotsArray.Length == 0)
                    validationErrors.Add("Timeslots array is empty. Provide valid input.");

                foreach (var timeSlot in timeSlotsArray)
                {
                    // Step 3 : Check if each timeslots has more than two numbers in the array then add validatoin error
                    if (timeSlot.Length > 2)
                        validationErrors.Add("One of the timeslot array contains more than two numbers. Its invalid input.");
                    // Step 4 : Check if each timeslots has less than two numbers in the array then add validation error
                    if (timeSlot.Length < 2)
                        validationErrors.Add("One of the timeslot array contains less than two numbers. Its invalid input.");

                    if(timeSlot.Length==2)
                    {
                        // Step 5 : Check if each timeslot's startminutes is possitive value else add validation error.
                        if (timeSlot[0]<0)
                            validationErrors.Add("One of the timeslot has start minutes a negetive value. Its invalid input.");
                        // Step 6 : Check if each timeslot's endminutes is possitive value else add validation error.
                        if (timeSlot[1] < 0)
                            validationErrors.Add("One of the timeslot has end minutes a negetive value. Its invalid input.");
                        // Step 7 : If the start minutes is greater than end minutes then add validation error
                        if (timeSlot[0] > timeSlot[1])
                            validationErrors.Add("One of the timeslot has start minutes greater than end minutes. Its invalid input.");
                    }
                    if (validationErrors.Any()) break;
                }
            }
            return !validationErrors.Any();
        }

        /// <summary>
        /// Get minimum and maximum time slots duration
        /// </summary>
        /// <param name="timeSlotsArrays">Input time slots array</param>
        /// <param name="minimumTimeSlotMin">Minimum timeslots minutes</param>
        /// <param name="maxTimeSlotMins">Maximum timeslots minutes</param>
        internal static void DetermineMinimumAndMaxTimeSlotDuration(this int[][] timeSlotsArrays, out int minimumTimeSlotMin, out int maxTimeSlotMins)
        {
            minimumTimeSlotMin = 0;
            maxTimeSlotMins = 0;
            if (timeSlotsArrays != null && timeSlotsArrays.Length > 0)
            {
                // Determine min and max timeslots
                minimumTimeSlotMin = timeSlotsArrays.ToList().Min(x => x[0]);
                maxTimeSlotMins = timeSlotsArrays.ToList().Max(x => x[1]);
            }
        }
        #endregion
    }
}
