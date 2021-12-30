import React from "react";
import Article from "../components/views/atoms/Article";

export default class ArchiveTemplate extends React.Component {
    render() {
        const { searchLocation, matchParams } = this.props;
        const query = new URLSearchParams(searchLocation)
        const { article } = matchParams;
        const date = query.get("date");
        const filter = query.get("filter");
        const Articles = [
            "Some Article",
            "Some Other Article",
            "Yet Another Article",
            "Still More",
            "Fake Article",
            "Partial Article",
            "American Article",
            "Mexican Article"
        ].map((title, i) => <Article key={i} title={title} />);

        return (
            <div>
                <h1>Archives</h1>
            article: {article}, date: {date}, filter: {filter}
                <div class="row">{Articles}</div>
            </div>
        );
    }
}