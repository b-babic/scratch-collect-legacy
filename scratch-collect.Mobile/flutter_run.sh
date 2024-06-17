#!/bin/bash

# Check if an argument was provided
if [ "$#" -ne 1 ]; then
  echo "Usage: ./run_flutter.sh [dev|prod]"
  exit 1
fi

FLAVOR=$1

# Run Flutter app based on the provided flavor
if [ $FLAVOR = "dev" ]; then
  flutter run --flavor=dev -t lib/main.dart --dart-define=FLAVOR=dev
elif [ $FLAVOR = "prod" ]; then
  flutter run --flavor=prod -t lib/main.dart --dart-define=FLAVOR=prod
else
  echo "Invalid flavor: $FLAVOR"
  echo "Usage: ./run_flutter.sh [dev|prod]"
  exit 1
fi
