Feature: StudentController
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowForStudentController/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
        Scenario: Get all students
        Given the StudentService returns a list of students
        When the client sends a request to get all students
        Then a list of students should be returned
    
@mytag
        Scenario: Get student by ID
        Given a student with ID 1 exists
        When the client sends a request to get the student with ID 1
        Then the response should be successful
        And the response should contain the details of the student with ID 1
@mytag
        Scenario: Create a new student
        Given a student with the following details:
            | Name            | PhoneNumber | EmailId               |
            | John Doe        | 1234567890  | john.doe@example.com  |
        When the client sends a request to create the student with details:
            | Name            | PhoneNumber | EmailId               |
            | John Doe        | 1234567890  | john.doe@example.com |

        Then the response should indicate successful creation

#@mytag
#        Scenario: Update student information
#        Given a student with ID 1 exists in list of students        
#       When the client sends a request to update the student with ID 1 and the following details:
#      | Name         | PhoneNumber | EmailId                   |
#      | Updated Name | 9876543210  | updated.email@example.com |
#        Then the response should be successful
#        And the response should contain the updated student details:
#            | ExpectedName       | ExpectedPhoneNumber | ExpectedEmailId           |
#            | Updated Name       | 9876543210          | updated.email@example.com |

@mytag
        Scenario: Delete a student by ID
        Given A student with ID 1 exist
        When the client sends a request to delete the student with ID 1
        Then the response should be successfull
        And the response should indicate that the student is deleted