import 'package:flutter/material.dart';
import 'package:IB210370/modules/home/home.screen.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/routes.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Scratch & Collect',
      theme: ThemeData(
        appBarTheme: const AppBarTheme(color: primaryColor),
        pageTransitionsTheme: const PageTransitionsTheme(builders: {
          TargetPlatform.android: CupertinoPageTransitionsBuilder(),
        }),
      ),
      // home: SplashScreen(), TODO: Set splash as root once finished
      initialRoute: HomeScreen.routeName,
      routes: routes,
    );
  }
}
