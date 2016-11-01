Feature: TestCarPark

Scenario: 1. Initialise the car park with 10 bays and a name of 'Test carpark'
	Given a car park with 10 bays and a name of "Test carpark"
	Then the car park should have 10 bays
	Then the car park name should be "Test carpark"


Scenario: 2.	Have one of each type of vehicles enter the car park. The truck should have a weight of 101 kg.
	Given a car park with 10 bays and a name of "Test carpark"
	And a "StandardCar" enters the car park
	And a "LuxuryCar" enters the car park
	And a "Motorbike" enters the car park
	And a "Truck" with a weight of 101 kgs enters the car park
	# List the details of all the vehicles in the car park including their type and outstanding fees.
	Then the vehicles details should look like this:
	| Output                                                  |
	| Id: 1 ShortDescription: StandardCar Fees: 7 IsFeePaid: False |
	| Id: 2 ShortDescription: LuxuryCar Fees: 10 IsFeePaid: False  |
	| Id: 3 ShortDescription: Motorbike Fees: 4 IsFeePaid: False   |
	| Id: 4 ShortDescription: Truck Fees: 15 IsFeePaid: False      |
	

	