# SchoolAPI
# ERD Daigram ![ERD](https://user-images.githubusercontent.com/65688803/123496837-1f612d00-d5f8-11eb-8f30-48116939f5d4.jpeg)

# Data Dictionaries
Data Dictionary for User Management 

Data Item/<br>Field Name|Data Type|Data Format|Number of Bytes per Storage|Size of display|Description|Example|
| :- | :- | :- | :- | :- | :- | :- |
|User ID|String|XXNNNN|6|6|Unique Identifier for User|PB1234|
|Username|Varchar||25|25|Full Name of user|Payal Bhalala|
|Password|VarChar|XXXXXNNS|15|8|Password for the User to login for the enrolled Course|Qwert12^|
|Email|String||60|30|Email Id of the user|Kbb1@njit.edu|
|Status|Boolean|X|1|1|<p>Enrolled(y) or</p><p>Not enrolled(N)</p>|Y|
|System Role ID|String|XNNN||4|System ID based on role If student or teacher|T123|
|Created Date|Floating Point<br>(Date Format)|DD/MM/YYYY|4|10|Date when Course created for user|03/21/1995|
|Updated date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Date when course is being updated|03/21/1995|

Data Dictionary for Section Enrollment Management

|Data Item/<br>Field Name|Data Type|Data Format|Number of Bytes per Storage|Size of display|Description|Example|
| :- | :- | :- | :- | :- | :- | :- |
|Section ID|Integer|NNN|1|3|Describes the section ID |123|
|User ID|String|XXNNNN|6|6|Unique Identifier for User|PB1234|
|Created Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Date when Course created for user|03/21/1995|
|Updated Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Date when course is being updated|03/21/1995|
|Start date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Start date of course|03/21/1995|
|End Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|End date of course|03/21/1995|

Data Dictionary for Course Section Management

|Data Item/<br>Field Name|Data Type|Data Format|Number of Bytes per Storage|Size of display|Description|Example|
| :- | :- | :- | :- | :- | :- | :- |
|Course Id|Integer|NNN NNN|4|7|Users course ID|690 850|
|Start Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Start date of course|03/21/1995|
|End Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|End date of course|03/21/1995|
|Created Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Date when Course created for user|03/21/1995|
|Updated Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Date when course is being updated|03/21/1995|

Data Dictionary for Course Management

|Data Item/<br>Field Name|Data Type|Data Format|Number of Bytes per Storage|Size of display|Description|Example|
| :- | :- | :- | :- | :- | :- | :- |
|Course Title|String||25|25|Name of the Course|Web Systems Development|
|Description|String|||30|Describe what type of course is like online, synchronous online or converged|Online|
|Created Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Date when Course created for user|03/21/1995|
|Updated Date|Floating Point<br>(Date Format|DD/MM/YYYY|4|10|Date when course is being updated|03/21/1995|

Data Dictionary for Course Assignment Management

|Data Item/<br>Field Name|Data Type|Data Format|Number of Bytes per Storage|Size of display|Description|Example|
| :- | :- | :- | :- | :- | :- | :- |
|Assignment Title|String||25|25|Name of the assignment assigned|Create a Calculator|
|Description|String|||30|Gives basic information for assignment like which language should be used.|Python|
|Course ID|Integer|NNN NNN|4|7|Users course ID|690 850|

#Screenshots for different Methods:

#GET Method:
![Get_Method](https://user-images.githubusercontent.com/65688803/126912993-ab4e2bae-790e-4c21-9205-1d7f32a5f9a0.PNG)

#POST Method & it's requested GET Method:
![Post_Method1](https://user-images.githubusercontent.com/65688803/126913012-9a9b8cb3-c231-4dc8-bbf1-d0de8713386e.PNG)
![Post_Method2](https://user-images.githubusercontent.com/65688803/126913023-dcc2adef-6a8c-4ebf-acf3-b50cc31eee22.PNG)

#PUT Method and it's requested GET Method:
![Put_Method1](https://user-images.githubusercontent.com/65688803/126913053-26dd5075-badf-4382-931e-c1be6117e2dd.PNG)
![Put_Method2](https://user-images.githubusercontent.com/65688803/126913059-0e190bfd-53f7-4612-b531-09298bd4449f.PNG)

#DELETE and it's requested GET Method:
![Delete_Method1](https://user-images.githubusercontent.com/65688803/126913080-c4308d50-e316-4023-995e-bddaf37a74c9.PNG)
![Delete_Method2](https://user-images.githubusercontent.com/65688803/126913088-069e0861-28f4-4164-bbfc-8f37ea175470.PNG)

