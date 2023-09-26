Feature: SpecFlowMenuTests
	In order to easily find needed documentation
	As a specflow user
	I want to be able to navigate to pages through main menu

@smoke
Scenario Outline: Clicking menu option from the main menu should open corresponding page
	Given I open official SpecFlow web site
	When I hover the '<menuItem>' menu item from the main menu
	And I click '<subMenuItem>' option from the main menu
	And I click on the '<leftMenuItem>' field
	And I enter the '<title>' in the popup window
	And I select the '<title>' result 
	Then Page with '<title>' title should be opened

	Examples: 
	| menuItem | subMenuItem |leftMenuItem  | title           |
	| Docs     | SpecFlow    | Search docs | Installation |