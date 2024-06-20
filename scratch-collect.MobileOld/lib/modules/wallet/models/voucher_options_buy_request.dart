class VoucherBuyRequest {
  String? userId;
  String? cardNumber;
  String? cvv;
  String? amount;
  String? expiryDate;

  VoucherBuyRequest({
    required this.userId,
    this.cardNumber,
    this.cvv,
    this.amount,
    this.expiryDate,
  });

  VoucherBuyRequest.fromJson(Map<String, dynamic> json) {
    userId = json['userId'];
    cardNumber = json['cardNumber'];
    cvv = json['cvv'];
    amount = json['amount'];
    expiryDate = json['expiryDate'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['userId'] = userId;
    data['cardNumber'] = cardNumber;
    data['cvv'] = cvv;
    data['amount'] = amount;
    data['expiryDate'] = expiryDate;

    return data;
  }
}
