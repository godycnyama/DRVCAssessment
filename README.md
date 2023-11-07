# Roulette Game API

## Overview

This project is a Roulette Game API based on .Net 7. It was designed following the Clean Architecture principles. It consists of 5 projects namely Roulette.API, Roulette.Application, Roulette.Infrastructure, Roulette.Domain and Roulette.UnitTests.
A number of designs patterns were used during the implemantation of the solution. The CQRS and Mediator patterns were used to implement the API and business logic in the Roulette.API and Roulette.Application projects. The MediatR library was utilised to implement these two patterns. In the infrastructure layer (Roulette.Infrastructure), the unit of work and repository patterns were utilised to interact with the database while utilising Entity Framework Core. SQLite was used as the database, and the database file, roulette.db is located in the Roulette.API project. SOLID principles and clean code principles were used throughout the solution code base. Using MediatR library helped a lot in in writing loosely coupled, easily testable, clean code. MSTest was utilised as the test framework.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Endpoints](#endpoints)
- [License](#license)

## Features

- Manage roulette game sessions.
- Manage bets placement.
- Manage roulette wheel spins and record the winning numbers.
- Manage accounts for players.
- Manage payouts. 

## Getting Started

Follow these steps to get started with the Roulette Game API:

1. **Prerequisites:**
   - [Visual Studio](https://visualstudio.microsoft.com/) installed on your system.
   - [.NET Core SDK 7](https://dotnet.microsoft.com/download/dotnet) for building and running the project.

2. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/roulette-game-api.git
   ```

3. **Open the project:**
   - Open the solution file `RouletteGame.sln` in Visual Studio.

4. **Build the project:**
   - Build the solution to restore dependencies and compile the code.

5. **Run the application:**
   - Start the application within Visual Studio or use the command line with the following command:
     ```bash
     dotnet run
     ```

6. **Access the API:**
   - The API will be available at `http://localhost:5000` (or a different URL, depending on your configuration).

## Usage

The Roulette Game API follows RESTful principles and can be used by sending HTTP requests to its endpoints. You can interact with the API using your favorite HTTP client 

## Endpoints

The API provides the following endpoints:

- `POST /api/game/start`: Start a new game session.
- `POST /api/game/bet`: Place a bet on the current game session.
- `POST /api/game/spin`: Spin the roulette wheel and determine the winning number.
- `GET /api/game/result`: Retrieve the game results and current balance.

For more details on request and response formats, refer to the [Sample Requests and Responses](#sample-requests-and-responses) section.

## Sample Requests and Responses

Here are some sample requests and responses for the API:

### Starting a New Game

**Request:**

```http
POST /api/game/start
```

**Response:**

```json
{
  "sessionId": "f27f7861-6ca4-4b6c-b3d9-4d9b6a6b66a8",
  "balance": 1000.0
}
```

### Placing a Bet

**Request:**

```http
POST /api/game/bet
```

**Request Body:**

```json
{
  "sessionId": "f27f7861-6ca4-4b6c-b3d9-4d9b6a6b66a8",
  "betAmount": 50.0,
  "betType": "red",
  "betNumber": 0
}
```

**Response:**

```json
{
  "message": "Bet placed successfully."
}
```

### Spinning the Wheel

**Request:**

```http
POST /api/game/spin
```

**Request Body:**

```json
{
  "sessionId": "f27f7861-6ca4-4b6c-b3d9-4d9b6a6b66a8"
}
```

**Response:**

```json
{
  "winningNumber": 7,
  "resultMessage": "You win $100.0!"
}
```

### Retrieving Game Results

**Request:**

```http
GET /api/game/result?f27f7861-6ca4-4b6c-b3d9-4d9b6a6b66a8
```

**Response:**

```json
{
  "sessionId": "f27f7861-6ca4-4b6c-b3d9-4d9b6a6b66a8",
  "balance": 950.0
}
```

## Configuration

You can configure the API by modifying the `appsettings.json` file in the project. It allows you to customize various settings such as the initial player balance, available bet types, and more.

## Contributing

If you'd like to contribute to this project, please follow these guidelines:

1. Fork the repository.
2. Create a feature branch.
3. Make your changes and commit them with descriptive messages.
4. Push your changes to your fork.
5. Create a pull request to the main repository.

Please ensure your code follows the project's coding standards and includes relevant tests.

## License

This project is licensed under the [MIT License](LICENSE). You are free to use, modify, and distribute the code as per the terms of the license.

Happy coding and enjoy your roulette game development with this API! If you have any questions or need further assistance, feel free to reach out to us.
