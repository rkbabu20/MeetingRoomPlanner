# Meeting Room Planner
This is a code sample algorithm for meeting room planner.

## Problem Statement
If list of intervals are given in array of array format then get minimum number of meeting rooms to schedule all meetings without overlap.
## Input Test Data Format
new int[ ][ ]</br>
    {</br>
    &nbsp;&nbsp;  [1,30],  // First meeting timeslot</br>
    &nbsp;&nbsp;  [10,15], // Second meetting timeslot</br>
    &nbsp;&nbsp;  [13,20], // Third meeting timeslot</br>
    &nbsp;&nbsp;  [15,20], // 4th meeting timeslot</br>
    &nbsp;&nbsp;  [20,45],  // 4th meeting timeslot</br>
    &nbsp;&nbsp;  // Additiona slots for testing purpose</br>
    &nbsp;&nbsp;  [30,35],</br>
    &nbsp;&nbsp;  [35,40],</br>
    &nbsp;&nbsp;  [1,5],</br>
    };</br>

## Response 
<---- M M E E T I N G  R O O M S  S C H E D U L E R ----></br>
All timeslots scheduled. 3 meeting rooms booked</br></br>
Number of bookings on this room : 3</br>
Booking Schedule StartMinutes: 1, EndMinutes: 30</br>
Booking Schedule StartMinutes: 30, EndMinutes: 35</br>
Booking Schedule StartMinutes: 35, EndMinutes: 40</br>

Number of bookings on this room : 3</br>
Booking Schedule StartMinutes: 20, EndMinutes: 45</br>
Booking Schedule StartMinutes: 13, EndMinutes: 20</br>
Booking Schedule StartMinutes: 1, EndMinutes: 5</br>
 
Number of bookings on this room : 2</br>
Booking Schedule StartMinutes: 10, EndMinutes: 15</br>
Booking Schedule StartMinutes: 15, EndMinutes: 20</br>

Enter any key to exit:</br>

## Solution Approach
1. Convert array of array in to meaningful TimeSlots List.
2. As there is no directions given how long each meeting room is available for booking, create a room with minimum start time across all times slots as start time for room availability. and maximum end time across all time slots as avaialble end time for booking.
3. Schedule time slots on that room as bookings based on avaialable time slots.
4. If any of the slots left unbooked then create another room and book rest of the time slots.
5. If any slots left unbooked again then follow the same logic described in step 4, in othe words call step 4 recursively until all time slots booked.

## Solution setup
1. Solution is implemented using Visual studio 2022 community edition and .net core 8.
2. Clone the repo to your local. Open the project and build.
3. No other pre requisites needed.
