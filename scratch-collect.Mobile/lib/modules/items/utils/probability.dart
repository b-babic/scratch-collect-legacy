import 'dart:math';

Future<bool> calculateWonProbability(int? price) async {
  if (price == null) return false;

  Random r = Random();
  double delta = 0.0;

  switch (price) {
    case 15:
      delta = 0.5;
      break;
    case 30:
      delta = 0.3;
      break;
    case 50:
      delta = 0.1;
      break;
    default:
      delta = 0.1;
      break;
  }

  bool result = r.nextDouble() <= delta;

  return result;
}
