// Base layout sizes based on most of the designs
import 'package:ib210370_desktop/modules/shared/theme/size_config.dart';

const double layoutHeight = 812.0;
const double layoutWidth = 375.0;

// Get the proportionate height as per screen size
double getProportionateScreenHeight(double inputHeight) {
  double screenHeight = SizeConfig.screenHeight;
  return (inputHeight / layoutHeight) * screenHeight;
}

// Get the proportionate width as per screen size
double getProportionateScreenWidth(double inputWidth) {
  double screenWidth = SizeConfig.screenWidth;
  return (inputWidth / layoutWidth) * screenWidth;
}
