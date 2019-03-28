Feature: Trello Board
Smoke CRUD Trello Board Scenarios

@Smoke
Scenario: Create Board with empty name
	Given Empty name as a Board name
	When New Board is Being Created
	Then Trello Service returns invalid value for name error

@Smoke
Scenario: Create Board with too long name
	Given Board with name longer than 16384 characters
	When New Board is Being Created
	Then Trello Service returns invalid value for name error

@Smoke
Scenario Outline: Create Board with set of predefined Options
	Given Board Creation Parameters ( <nameParam>, <descParam>, <defaultListsParam>, <defaultLabelsParam>, <idOrganizationParam>)
	When New Board is Being Created
	Then Trello Service returns Board Entity with options ( <nameResult>, <idOrganizationResult>, <descResult>, <descDataResult>, <closedResult>, <pinnedResult>)

Examples: 
| case               | nameParam          | descParam   | defaultListsParam | defaultLabelsParam | idOrganizationParam | nameResult         | idOrganizationResult | descResult  | descDataResult | closedResult | pinnedResult |
| Happy path         | Some ordinary name |             |                   |                    |                     | Some ordinary name |                      |             |                | false        | false        |
| MinValue for name  | a                  |             |                   |                    |                     | a                  |                      |             |                | false        | false        |
| DescriptionFilled  | Some ordinary name | Description |                   |                    |                     | Some ordinary name |                      | Description |                | false        | false        |
| DefaultListsTrue   | Some ordinary name |             | true              |                    |                     | Some ordinary name |                      |             |                | false        | false        |
| DefaultListsFalse  | Some ordinary name |             | false             |                    |                     | Some ordinary name |                      |             |                | false        | false        |
| DefaultLabelsTrue  | Some ordinary name |             |                   | true               |                     | Some ordinary name |                      |             |                | false        | false        |
| DefaultLabelsFalse | Some ordinary name |             |                   | false              |                     | Some ordinary name |                      |             |                | false        | false        |

Scenario: Read
	Given Default Board with predefined Lists
	When Default Board is Being Read
	Then Trello Service returns Board Entity with options (Default name, Default idOrganization, Default desc, , false, false)

Scenario: Update
	Given Default Board with predefined Lists
	When Default Board Name is Updated
	Then Trello Service returns Board Entity with options (Updated name, Default idOrganization, Default desc, , false, false)

Scenario: Delete
	Given Default Board with predefined Lists
	When Default Board is Deleted
	Then Trello Service returns no default board
