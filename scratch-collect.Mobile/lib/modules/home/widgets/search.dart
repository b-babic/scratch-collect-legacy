import 'dart:async';

import 'package:flutter/material.dart';

class Search extends StatefulWidget {
  final Function? onSearch;

  const Search({super.key, this.onSearch});

  @override
  SearchState createState() => SearchState();
}

class SearchState extends State<Search> {
  Timer? _debounce;
  TextEditingController searchController = TextEditingController();

  _onSearchChanged(String query) {
    if (_debounce?.isActive ?? false) _debounce?.cancel();
    _debounce = Timer(const Duration(milliseconds: 500), () {
      if (widget.onSearch != null) widget.onSearch!(query);
    });
  }

  @override
  void dispose() {
    _debounce?.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return TextField(
      onChanged: (value) => _onSearchChanged(value),
      controller: searchController,
      decoration: InputDecoration(
        border: const OutlineInputBorder(),
        hintText: 'Please enter a search term',
        suffixIcon: IconButton(
          onPressed: (() {
            searchController.clear();
            widget.onSearch!("");
          }),
          icon: const Icon(Icons.clear),
        ),
      ),
    );
  }
}
