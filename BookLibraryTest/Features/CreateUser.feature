Feature: CreateUser

A short summary of the feature

@tag1
Scenario: Create user
	Given to create new User - username email password with 
	"""
	{
			"userName": "test123",
			"emailAddress": "test123@test.bg",
			"password": "test1234"
	}
	"""
	When user sends a post request with url as "http://localhost:5000/Authentication/create-user"
	Then request should be a success with 200s code
