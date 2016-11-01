Feature: OrWithInverter

@OrWithInverter
Scenario: Or with inverter for input one is false and input two is false
	Given Agenda agendaOne
	Given Wire inverterInput
	Given Wire inverterOutput
	Given Wire orInput
	Given Wire orOutput
	Given Inverter inverterOne using agenda agendaOne with input inverterInput and output inverterOutput
	Given Or orOne using agenda agendaOne with input one inverterOutput and input two orInput and output orOutput
	Given Probe probeOne using agenda agendaOne on wire orOutput
	When the signal on the wire inverterInput is false at time 0
	When the signal on the wire orInput is false at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [5,1][9,1]

Scenario: Or with inverter for input one is true and input two is false
	Given Agenda agendaOne
	Given Wire inverterInput
	Given Wire inverterOutput
	Given Wire orInput
	Given Wire orOutput
	Given Inverter inverterOne using agenda agendaOne with input inverterInput and output inverterOutput
	Given Or orOne using agenda agendaOne with input one inverterOutput and input two orInput and output orOutput
	Given Probe probeOne using agenda agendaOne on wire orOutput
	When the signal on the wire inverterInput is true at time 0
	When the signal on the wire orInput is false at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [5,0][9,0]

Scenario: Or with inverter for input one is false and input two is true
	Given Agenda agendaOne
	Given Wire inverterInput
	Given Wire inverterOutput
	Given Wire orInput
	Given Wire orOutput
	Given Inverter inverterOne using agenda agendaOne with input inverterInput and output inverterOutput
	Given Or orOne using agenda agendaOne with input one inverterOutput and input two orInput and output orOutput
	Given Probe probeOne using agenda agendaOne on wire orOutput
	When the signal on the wire inverterInput is false at time 0
	When the signal on the wire orInput is true at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [5,1][9,1]

Scenario: Or with inverter for input one is true and input two is true
	Given Agenda agendaOne
	Given Wire inverterInput
	Given Wire inverterOutput
	Given Wire orInput
	Given Wire orOutput
	Given Inverter inverterOne using agenda agendaOne with input inverterInput and output inverterOutput
	Given Or orOne using agenda agendaOne with input one inverterOutput and input two orInput and output orOutput
	Given Probe probeOne using agenda agendaOne on wire orOutput
	When the signal on the wire inverterInput is true at time 0
	When the signal on the wire orInput is true at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [5,1][9,1]
