Feature: Probe
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@RealTimeProbe
Scenario: Probe shows signal on wire for signal is true
	Given Agenda agendaOne
	Given Wire input
	Given Probe probeOne using agenda agendaOne on wire input
	When the signal on the wire input is true at time 0
	When Agenda agendaOne is processed
	Then the probe probeOne should show true

Scenario: Probe shows signal on wire for signal is false
	Given Agenda agendaOne
	Given Wire input
	Given Probe probeOne using agenda agendaOne on wire input
	When the signal on the wire input is false at time 0
	When Agenda agendaOne is processed
	Then the probe probeOne should show false

Scenario: Probe creates log for single change
	Given Agenda agendaOne
	Given Wire input
	Given Probe probeOne using agenda agendaOne on wire input
	When the signal on the wire input is true at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [0,1]

Scenario: Probe creates log for multiple changes
	Given Agenda agendaOne
	Given Wire input
	Given Probe probeOne using agenda agendaOne on wire input
	When the signal on the wire input is true at time 0
	When Agenda agendaOne is processed
	When the signal on the wire input is false at time 1
	When Agenda agendaOne is processed
	When the signal on the wire input is true at time 2
	When Agenda agendaOne is processed
	When the signal on the wire input is false at time 3
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [0,1][1,0][2,1][3,0]
