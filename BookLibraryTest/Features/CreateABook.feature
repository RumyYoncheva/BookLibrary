Feature: CreateABook

A short summary of the feature

@tag2
Scenario: Create a new book
	Given I am a client
	When I make a post request to 'http://localhost:5000/Books' with the following data '{"title": "Being a god","author": {"firstName": "Ivan","lastName": "Banchev","dateOfBirth": "1995-08-17T18:33:55.988Z"},"publisher": "Bok","releaseDate": "2022-08-17T18:33:55.988Z"}'
	Then the response status code is '200'
	And the response data should be '{"id":1}'
