Project: RainFall - Exam

Description
	This project (application) was done due to requirement (as an exam) from Dev Partners. The program/sources was written on C#, .net 7.0. Get-rainfall reading from Department for Environment Food & Rural Affairs (UK) by using there public API

	Tech/Framework
	1. MVC
	2. Clean Architecture
	3. Domain Driven

	Features
		Get rainfall reading from Department for Environment Food & Rural Affairs (UK) by using there public API

Dependencies
	Build
			The current version is in 1.0.0 (format - Major, Minor, Patch). The build will be just run an API and use Swagger to test them.
		The build uses the following packages:
		1. Microsoft.AspNetCore.OpenApi
		2. Swashbuckle.AspNetCore
		3. Swashbuckle.AspNetCore.Annotations
		4. Newtonsoft.Json

	API reference
	External
		Environment Agency Real Time flood-monitoring API
		1. https://environment.data.gov.uk/flood-monitoring/id/stations/3680/readings?_sorted&_limit=100
	From App
		1. /rainfall/id/{stationId}/readings
		- use to get readings per station and no limit on count of readings
		2. /rainfall/id/{stationId}/{count}/readings
		- use to get readings per station and with limit on count of readings
		3. /rainfall/{stationId}/{count}
		4. Use "?limit={count}" at the end of the URL where "count" is the number of limit

How to run the project
1. Go to https://github.com/cesarbalangue/RainFallAPI
2. Download repository
3. Open source using Microsoft Visual Studio Community 2022 (64-bit) 
4. Build (or re-build)
5. Run the sources








