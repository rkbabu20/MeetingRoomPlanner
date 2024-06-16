# MeetingRoomPlanner
This is a code sample algorithm for meeting room planner.

# Problem statement
If list of intervals are given in array of array format then get minimum number of meeting rooms to schedule all meetings without overlap.
## Input Format

new int[][]
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

# Solution Approach
1. Convert array array in to meaningful TimeSlots List.
2. As there is no directions given how long each meeting room is available for booking, create a room with minimum start time time and maximum end time as avaialble time for booking.
3. Schedule time slots on that room as bookings based on avaialable time slots.
4. If any of the slots left unbooked then create another room and book rest of the slots.
5. If any slots left unbooked then follow the same logic described in step 4.

# Response 
<--- M E E T I N G  R O O M S  S C H E D U L E R --->
-------------------------------------------------------------------------
All timeslots scheduled. 3 meeting rooms booked
-------------------------------------------------------------------------
Number of bookings on this room : 3
Booking Schedule StartMinutes: 1, EndMinutes: 30
Booking Schedule StartMinutes: 30, EndMinutes: 35
Booking Schedule StartMinutes: 35, EndMinutes: 40
-------------------------------------------------------------------------
Number of bookings on this room : 3
Booking Schedule StartMinutes: 20, EndMinutes: 45
Booking Schedule StartMinutes: 13, EndMinutes: 20
Booking Schedule StartMinutes: 1, EndMinutes: 5
-------------------------------------------------------------------------
Number of bookings on this room : 2
Booking Schedule StartMinutes: 10, EndMinutes: 15
Booking Schedule StartMinutes: 15, EndMinutes: 20
-------------------------------------------------------------------------
Enter any key to exit:

# Solution setup
1. Solution is implemented using Visual studio 2022 community edition and .net core 8.
2. Clone the repo to your local. Open the project and build
3. No other pre requisites needed.