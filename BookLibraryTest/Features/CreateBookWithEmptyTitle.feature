Feature: CreateBookWithEmptyTitle

A short summary of the feature

@tag1
Scenario: Create Book With Empty Title
	Given I am an existing client
	When I make a post request to 'http://localhost:5000/Books' with the following wrong data '{"title": "","author": {"firstName": "Author","lastName": "Author","dateOfBirth": "1995-08-17T18:33:55.988Z"},"publisher": "Publisher","releaseDate": "2022-08-17T18:33:55.988Z"}'
	Then the bad request response status code is '400'
	And the bad request response data should be 'Title must not be empty'
