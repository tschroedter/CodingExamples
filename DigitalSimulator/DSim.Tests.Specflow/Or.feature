Feature: Or
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@RealTimeOr
Scenario: Or output is false for input one is false and input two is false
	Given Agenda agendaOne
	Given Wire inputOne
	Given Wire inputTwo
	Given Wire output
	Given Or orOne using agenda agendaOne with input one inputOne and input two inputTwo and output output
	Given Probe probeOne using agenda agendaOne on wire output
	When the signal on the wire inputOne is false at time 0
	When the signal on the wire inputTwo is false at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [5,0][5,0]

Scenario: Or output is true for input one is true and input two is false
	Given Agenda agendaOne
	Given Wire inputOne
	Given Wire inputTwo
	Given Wire output
	Given Or orOne using agenda agendaOne with input one inputOne and input two inputTwo and output output
	Given Probe probeOne using agenda agendaOne on wire output
	When the signal on the wire inputOne is true at time 0
	When the signal on the wire inputTwo is false at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [5,1][5,1]

Scenario: Or output is true for input one is false and input two is true
	Given Agenda agendaOne
	Given Wire inputOne
	Given Wire inputTwo
	Given Wire output
	Given Or orOne using agenda agendaOne with input one inputOne and input two inputTwo and output output
	Given Probe probeOne using agenda agendaOne on wire output
	When the signal on the wire inputOne is false at time 0
	When the signal on the wire inputTwo is true at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [5,1][5,1]

Scenario: Or output is true for input one is true and input two is true
	Given Agenda agendaOne
	Given Wire inputOne
	Given Wire inputTwo
	Given Wire output
	Given Or orOne using agenda agendaOne with input one inputOne and input two inputTwo and output output
	Given Probe probeOne using agenda agendaOne on wire output
	When the signal on the wire inputOne is true at time 0
	When the signal on the wire inputTwo is true at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [5,1][5,1]
