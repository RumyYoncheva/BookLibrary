Feature: CreateBook

A short summary of the feature

@tag1
Scenario: Create Book
	Given The book details
	"""
	{
		"title": "Book1",
		"author": {
		"firstName": "Jhon",
		"lastName": "Doe",
		"dateOfBirth": "1987-08-16T08:01:32.778Z"
	},
	"publisher": "BestPublisher",
	"releaseDate": "2022-08-16T08:01:32.778Z"
	}
	"""
	When user sends a POST request with url as "http://localhost:5000/Books"
	Then request should be with 200s success codes

