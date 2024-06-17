# Meeting Room Planner
This is a code algorithm for meeting room planner. Implemented as a console application.

## Problem Statement
If list of intervals are given in an array of arrays format then get minimum number of meeting rooms to schedule all meetings without overlap.

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

## Execution Results 
<---- M E E T I N G &nbsp; R O O M S &nbsp; S C H E D U L E R ----></br>
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
1. Convert array of array in to meaningful TimeSlots entities list.
2. As there are no directions given how long each meeting room is available for booking, I created a room with minimum start time across all times slots as start time for room availability, and maximum end time across all time slots as avaialble end time for booking.
3. Check if the timeslot can be booked on the available timeslot by comparing the start and end times. 
4. Book the timeslot and split the available timeslot by subtracting booked timeslot time. 
5. Complete the same process for each timeslot.
6. If any of the slots left unbooked, it means that there is no sufficient time available for booking as per the requested timeslots. 
7. So, then create another room and book rest of the time slots by following the same process as above.
8. If any slots left unbooked, then again follow the same logic described in step 4,5,6 and 7. (Recursion logic)
9. Refer solution for the better understanding.

## Solution setup
1. Solution is implemented using Visual studio 2022 community edition and .net core 8.
2. Clone the repo to your local. Open the project and build.
3. No other pre requisites needed except .net core 8.  
