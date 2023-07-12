import 'dart:io';

import 'package:dio/dio.dart';
import 'package:IB210370/modules/shared/constants.dart';
import 'package:IB210370/modules/shared/utils/api/interceptors.dart';
import 'package:dio/io.dart';

class Api {
  final dio = createDio();
  final tokenDio = Dio(BaseOptions(baseUrl: url));

  Api._internal();

  static final _singleton = Api._internal();

  factory Api() => _singleton;

  static Dio createDio() {
    var dio = Dio(BaseOptions(
      baseUrl: url,
      receiveTimeout: const Duration(seconds: 20000), // 20 seconds
      connectTimeout: const Duration(seconds: 20000),
      sendTimeout: const Duration(seconds: 20000),
    ));

    dio.interceptors.addAll({
      AppInterceptors(dio),
    });

    // Handle localhost TLS handshake

    // NOTE: Deprecated code (used in old dio versions)
    // (dio.httpClientAdapter as DefaultHttpClientAdapter).onHttpClientCreate =
    //     (HttpClient dioClient) {
    //   dioClient.badCertificateCallback =
    //       ((X509Certificate cert, String host, int port) => true);
    //   return dioClient;
    // };

    // dio.httpClientAdapter = IOHttpClientAdapter(
    //   onHttpClientCreate: (client) {
    //     client.badCertificateCallback =
    //         (X509Certificate cert, String host, int port) => true;
    //     return client;
    //   },
    // );

    dio.httpClientAdapter = IOHttpClientAdapter(
      createHttpClient: () => HttpClient()
        ..badCertificateCallback =
            ((X509Certificate cert, String host, int port) => true),
    );

    return dio;
  }
}
