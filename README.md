Auction Chat Application
Overview
This project involves building an auction chat application with an asynchronous communication system for enhanced real-time communication during bidding processes. The system allows users to enter a bidding room, submit bids, and notifies the highest bidder at the end of the auction. It also automatically creates an invoice for the highest bidder.

How It Works
Auction Item Creation: An item to be auctioned is created. During this process, the user has an option to set IsAuctionAvailable to true. When set to true, the item is created and the auction starts. The auction stops when the set time elapses.
Auction Room Entry: The item moves to RoomsController/AuctionedItems where users can view the item and decide to place a bid. This is where the Room Service comes into play. When a user enters a bidding room and the auction starts, the Room Service sends a message to the Bidding Service to activate and monitor the bidding process.
Bid Submission: Users can bid for an item using the ItemUniqueNumber in BidsController. When a bid is submitted, it is recorded in Rooms/Bids. The Bidding Service communicates with the Notification Service as bids are submitted and updated. This connection is used to send real-time updates or alerts to all participants in the auction room, ensuring they are informed of the current highest bid and any other relevant auction events.
Highest Bid Tracking: The bid with the highest amount is recorded in Room/HighestBid. Once the auction concludes, the Notification Service communicates with the Invoice Service. This message’s purpose is to initiate the generation of an invoice for the highest bidder, detailing the winning bid.
This process ensures a smooth and interactive auction experience, keeping all participants informed in real-time and providing a transparent and fair bidding environment.

Current Implementation
Controllers
AuctionItemsController: Handles CRUD operations for auction items.
BidsController: Allows users to submit bids and publishes a message to RabbitMQ with bid details.
PaymentsController: Currently has a placeholder endpoint for invoice generation and payment processing (to be implemented).
RoomsController: Retrieves a list of auctioned items, bids, and the highest bid.
Services
AuctionItemService: Implements logic for managing auction items (CRUD operations).
BiddingService: Handles retrieving auction items by unique number and creating new bids.
InvoiceService: Generates an invoice for the highest bidder and publishes a message to RabbitMQ.
PaymentService: Placeholder service for payment processing (to be implemented).
Data Access Layer
AuctionChatAppDbContext: Entity Framework Core context class for interacting with the database.
Messaging with RabbitMQ
The code currently uses RabbitMQ for communication between services:

Bid submission (BidsController) publishes a message with bid details to the notificationQueue.
Invoice generation (InvoiceService) publishes a message with invoice details to the paymentQueue.
Missing Implementation
The PaymentsController.Pay endpoint is a placeholder and needs implementation for processing payments.
Real-time chat implementation.
Future Development
Implement the payment processing logic in PaymentsController (e.g., integrating with a payment gateway).
Enhance error handling to provide more specific user feedback.
Consider user authentication and authorization for secure access to functionalities.
Explore implementing a real-time chat feature for auction rooms (using WebSockets or SignalR).
