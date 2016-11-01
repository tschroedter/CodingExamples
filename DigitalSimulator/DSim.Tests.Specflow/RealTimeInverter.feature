Feature: RealTimeInverter

@RealTimeInverter
Scenario: True becomes false
	Given Agenda agendaOne
	Given Wire inverterInput
	Given Wire inverterOutput
	Given Inverter inverterOne using agenda agendaOne with input inverterInput and output inverterOutput
	Given Probe probeOne using agenda agendaOne on wire inverterOutput
	When the signal on the wire inverterInput is true at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [4,0]
	# Then the wire inverterOutput is false

Scenario: False becomes true
	Given Agenda agendaOne
	Given Wire inverterInput
	Given Wire inverterOutput
	Given Inverter inverterOne using agenda agendaOne with input inverterInput and output inverterOutput
	Given Probe probeOne using agenda agendaOne on wire inverterOutput
	When the signal on the wire inverterInput is false at time 0
	When Agenda agendaOne is processed
	Then the log for probe probeOne should show [4,1]
	#Then the wire inverterOutput is true
