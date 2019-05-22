import React from 'react';
import { Post } from '@/Post';
import { statisticsService, authenticationService, postService } from '@/_services';

class HomePage extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            currentUser: authenticationService.currentUserValue,
            posts: null,
            statistics: {},
        };
    }

    componentDidMount() {
        statisticsService.getStatistics().then(statistics => this.setState({ statistics }))
        postService.getPosts().then(posts => this.setState({ posts }))
    }
    handleClick(id){

    }

    render() {
        const { currentUser, posts, statistics  } = this.state;
        return (
            <div>
                <div className="container">
                    <div className="row">
                       <div className="col-6">
                          {statistics.posts &&
                           statistics.posts.map((post) => (
                              <Post 
                                key={post.id} 
                                post={post} 
                                shouldShowCounter={true}
                                handleClick={this.handleClick}
                            />))}
                    </div>
                    <div className="col-6">
                        <h1>Hi {currentUser.firstName}!</h1>
                        <h4>Site statistics -</h4>
                        <h3> Total visits : {statistics.visits}</h3>
                        <h3> Unique visits : {statistics.uniqueVisits}</h3>
                        <h3> Total clicks : {statistics.overallClicks}</h3>
                        <h3> Unique clicks : {statistics.overallUniqueClicks}</h3>
                    </div>
                </div>
            </div>
          </div>
        );
    }
}

export { HomePage };