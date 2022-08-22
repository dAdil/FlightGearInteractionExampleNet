# FlightGear interaction example

This repo provides a minimal example of how to replace the flight dynamics model in 
FlightGear with an external one, provided by a .NET core application. This could be
used to create and fly your own simulation code without having to provide any 
graphics or scenery.

## Usage

1. [Download](https://www.flightgear.org/download/) and install FlightGear onto 
   your machine.
2. Copy the files from the `Config` directory into FlightGear's `/data/Protocol`
   folder. On Windows machines, this is typically found under the following path:
   `C:\\Program Files\\FlightGear <version>`
3. Run FlightGear from the `startFlightGear.bat` file provided. If you use linux,
   a different version of FlightGear or a different install path, you will need
   to modify accordingly.
4. Run this .NET core app your favourite way - `dotnet run`, debugging in an IDE
   etc.
5. To "fly" this simulation, press the `Tab` key in FlightGear to change into mouse
   steering. 

## How it works

Firstly, we configure FlightGear to run in the following ways:
- Disable the Flight Dynamics Model within the application. This stops FlightGear
  from running it's own aircraft simulation. 
- Configure FlightGear to send aircraft controls (throttle, ailerons, elevator, 
  rudder etc) frequently over UDP.
- Configure FlightGear to read aircraft position and orientation frequently over
  UDP.

We then run a .NET core app which can send and receive over the same protocol and
run it's own simulation loop. In this repository, we do not build a simulation 
model, but simply rotate the aircraft based on the inputs provided. 

## Side note

FlightGear can be configured to input or output most values in it's 
[Property Tree](https://wiki.flightgear.org/Aircraft_properties_reference) over a
variety of protocols. 

This can be used to experiment with all sorts of things without modifying or
interacting with the core FlightGear codebase. For example, it can be used to 
create experimental autopilots, external gauges or even custom input devices.
