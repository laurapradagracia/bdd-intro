Feature: Contract API token fetching

A short summary of the feature

@tag1
Scenario: Get token fails when invalid credentials
	Given invalid crentials
	When new token requested
	Then the result is unauthorized
