def multiple_events_recursion(events):
    if not events:
        return 0
    current_event, remaining_events = events[0], events[1:]

    option_1 = current_event + multiple_events_recursion(remaining_events)
    print("option_1 -> after", option_1)

    option_2 = multiple_events_recursion(remaining_events)
    print("option_2", option_2)

    return max(option_1, option_2)

# def calculate_max_events(events: list) -> int:


if __name__ == "__main__":
    list = [1,2,3,4,5]
    multiple_events_recursion(list)