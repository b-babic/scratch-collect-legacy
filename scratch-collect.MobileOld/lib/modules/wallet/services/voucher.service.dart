import 'dart:convert';

import 'package:IB210370/modules/shared/utils/api/api.dart';
import 'package:IB210370/modules/wallet/models/use_voucher_request.dart';
import 'package:IB210370/modules/wallet/models/voucher_options_buy_request.dart';
import 'package:IB210370/modules/wallet/models/wallet.model.dart';

class VoucherService {
  static VoucherService? _instance;

  factory VoucherService() => _instance ??= VoucherService._();

  VoucherService._();

  Future<Wallet> useCoupon(UseVoucherRequest request) async {
    var response =
        await Api().dio.post('/coupon/use', data: jsonEncode(request.toJson()));

    return Wallet.fromJson(response.data);
  }

  Future<Wallet> buyOption(VoucherBuyRequest request) async {
    var response =
        await Api().dio.post('/coupon/buy', data: jsonEncode(request.toJson()));

    return Wallet.fromJson(response.data);
  }
}
